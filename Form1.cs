using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;
namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int difficulty;
        public static bool AIGame;
        public static bool PlayerGame;
        public static bool turn;
        public static int iturn;
        public static int turncount;
        public static int AIScore;
        public static bool Winner;
        public static List<Button> Buttons = null;
        public static Button move = null;
        // parsed values
        public static int idraws;
        public static int iplayer1wins;
        public static int iplayer2wins;
        public static int iplayer1losses;
        public static int iplayer2losses;
        public enum Turn
        {
            X,
            O
        }
        public void SetTurn()
        {
            Random rnd = new Random();
            iturn = rnd.Next(0, 2);
        }
        public void GetButtons()
        {         
            Buttons = new List<Button>() { bottomleft, bottommiddle, bottomright, secondright, secondmiddle, secondleft, topright, topmiddle, topleft };
        }
        public int RandomCorner()
        {
          int corner = random_except_list(8, new int[] { 1, 3, 4, 5, 7 });
          return corner;
        }
        public bool ParseValues()
        {        
            if (int.TryParse(numdraws.Text, out idraws) && int.TryParse(p1wins.Text, out iplayer1wins) && int.TryParse(p2wins.Text, out iplayer2wins) && int.TryParse(p1losses.Text, out iplayer1losses) && int.TryParse(p2losses.Text, out iplayer2losses))
            {
                return true;
            }
            return false;
        }
        public static int random_except_list(int n, int[] x)
        {
            Random r = new Random();
            int result = r.Next(n - x.Length);

            for (int i = 0; i < x.Length; i++)
            {
                if (result < x[i])
                    return result;
                result++;
            }
            return result;
        }
        public void NewGame()
        {
            DialogResult dialogResult = MessageBox.Show("Would You Like To Play Again?", "Play Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
            {
                if (AIGame)
                {
                    StartAIGame();
                }
                else if (PlayerGame)
                {
                    StartPlayerGame();
                }
            }
                else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        public void HighlightWinner()
        {
            if (bottomleft.Text == Turn.X.ToString() & bottommiddle.Text == Turn.X.ToString() & bottomright.Text == Turn.X.ToString())
            {
                bottomleft.BackColor = Color.Red;
                bottommiddle.BackColor = Color.Red;
                bottomright.BackColor = Color.Red;
            }
            if(secondleft.Text == Turn.X.ToString() & secondmiddle.Text == Turn.X.ToString() & secondright.Text == Turn.X.ToString())
            {
                secondleft.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                secondright.BackColor = Color.Red;
            }
            if(topleft.Text == Turn.X.ToString() & topmiddle.Text == Turn.X.ToString() & topright.Text == Turn.X.ToString())
            {
                topleft.BackColor = Color.Red;
                topmiddle.BackColor = Color.Red;
                topright.BackColor = Color.Red;
            }
            // vertical checks
            if(bottomleft.Text == Turn.X.ToString() & secondleft.Text == Turn.X.ToString() & topleft.Text == Turn.X.ToString())
            {
                bottomleft.BackColor = Color.Red;
                secondleft.BackColor = Color.Red;
                topleft.BackColor = Color.Red;
            }
            if(bottommiddle.Text == Turn.X.ToString() & secondmiddle.Text == Turn.X.ToString() & topmiddle.Text == Turn.X.ToString())
            {
                bottommiddle.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                topmiddle.BackColor = Color.Red;
            }
            if(bottomright.Text == Turn.X.ToString() & secondright.Text == Turn.X.ToString() & topright.Text == Turn.X.ToString())
            {
                bottomright.BackColor = Color.Red;
                secondright.BackColor = Color.Red;
                topright.BackColor = Color.Red;
            }
            // diagonal checks
            if(bottomright.Text == Turn.X.ToString() & secondmiddle.Text == Turn.X.ToString() & topleft.Text == Turn.X.ToString())
            {
                bottomright.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                topleft.BackColor = Color.Red;
            }
            if(bottomleft.Text == Turn.X.ToString() & secondmiddle.Text == Turn.X.ToString() & topright.Text == Turn.X.ToString())
            {
                bottomleft.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                topright.BackColor = Color.Red;
            }
            // O's
            if (bottomleft.Text == Turn.O.ToString() & bottommiddle.Text == Turn.O.ToString() & bottomright.Text == Turn.O.ToString())
            {
                bottomleft.BackColor = Color.Red;
                bottommiddle.BackColor = Color.Red;
                bottomright.BackColor = Color.Red;
            }
            if (secondleft.Text == Turn.O.ToString() & secondmiddle.Text == Turn.O.ToString() & secondright.Text == Turn.O.ToString())
            {
                secondleft.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                secondright.BackColor = Color.Red;
            }
            if (topleft.Text == Turn.O.ToString() & topmiddle.Text == Turn.O.ToString() & topright.Text == Turn.O.ToString())
            {
                topleft.BackColor = Color.Red;
                topmiddle.BackColor = Color.Red;
                topright.BackColor = Color.Red;
            }
            // vertical checks
            if (bottomleft.Text == Turn.O.ToString() & secondleft.Text == Turn.O.ToString() & topleft.Text == Turn.O.ToString())
            {
                bottomleft.BackColor = Color.Red;
                secondleft.BackColor = Color.Red;
                topleft.BackColor = Color.Red;
            }
            if (bottommiddle.Text == Turn.O.ToString() & secondmiddle.Text == Turn.O.ToString() & topmiddle.Text == Turn.O.ToString())
            {
                bottommiddle.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                topmiddle.BackColor = Color.Red;
            }
            if (bottomright.Text == Turn.O.ToString() & secondright.Text == Turn.O.ToString() & topright.Text == Turn.O.ToString())
            {
                bottomright.BackColor = Color.Red;
                secondright.BackColor = Color.Red;
                topright.BackColor = Color.Red;
            }
            // diagonal checks
            if (bottomright.Text == Turn.O.ToString() & secondmiddle.Text == Turn.O.ToString() & topleft.Text == Turn.O.ToString())
            {
                bottomright.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                topleft.BackColor = Color.Red;
            }
            if (bottomleft.Text == Turn.O.ToString() & secondmiddle.Text == Turn.O.ToString() & topright.Text == Turn.O.ToString())
            {
                bottomleft.BackColor = Color.Red;
                secondmiddle.BackColor = Color.Red;
                topright.BackColor = Color.Red;
            }
        }
        public bool CheckWinner(string one, string two, string three)
        {
            if (one == Turn.X.ToString() && two == Turn.X.ToString() && three == Turn.X.ToString())
            {
                MessageBox.Show("Player 1 Wins!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParseValues();
                Winner = true;
                iplayer1wins = iplayer1wins + 1;
                p1wins.Text = iplayer1wins.ToString();
                iplayer2losses = iplayer2losses + 1;
                p2losses.Text = iplayer2losses.ToString();
                NewGame();
                return true;
            }
            else if (Turn.O.ToString() == one && Turn.O.ToString() == two && Turn.O.ToString() == three)
            {
                MessageBox.Show("Player 2 Wins!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Button button in groupBox2.Controls.OfType<Button>())
                {
                    button.Text = String.Empty;
                    button.Enabled = true;
                    button.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    button.BackColor = Color.WhiteSmoke;
                }
                ParseValues();
                Winner = true;
                iplayer2wins = iplayer2wins + 1;
                p2wins.Text = iplayer2wins.ToString();
                iplayer1losses = iplayer1losses + 1;
                p1losses.Text = iplayer1losses.ToString();
                NewGame();
                return true;
            }
            return false;
        }
        public bool CheckDraw()
        {
            foreach (Button button in groupBox2.Controls.OfType<Button>())
            {
                if (button.Text != String.Empty)
                {
                    if (!CheckWinner(bottomleft.Text, bottommiddle.Text, bottomright.Text))
                    {
                        if (!CheckWinner(secondleft.Text, secondmiddle.Text, secondright.Text))
                        {
                            if (!CheckWinner(topleft.Text, topmiddle.Text, topright.Text))
                            {
                                if (!CheckWinner(bottomleft.Text, secondleft.Text, topleft.Text))
                                {
                                    if (!CheckWinner(bottommiddle.Text, secondmiddle.Text, topmiddle.Text))
                                    {
                                        if (!CheckWinner(bottomright.Text, secondright.Text, topright.Text))
                                        {
                                            if (!CheckWinner(bottomright.Text, secondmiddle.Text, topleft.Text))
                                            {
                                                if (!CheckWinner(bottomleft.Text, secondmiddle.Text, topright.Text))
                                                {
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                                   
                            }
                        }
                    }
                }
            }
            return false;
        }
        public void StartPlayerGame()
        {
            PlayerGame = true;
            AIGame = false;
            Winner = false;
            turncount = 0;
            foreach (Button button in groupBox2.Controls.OfType<Button>())
            {
                button.Text = String.Empty;
                button.Enabled = true;
                button.BackColor = Color.WhiteSmoke;
            }
            SetTurn();
            if (iturn == 0)
            {
                MessageBox.Show("Player 1 Goes First!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (iturn == 1)
            {
                MessageBox.Show("Player 2 Goes First!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void StartAIGame()
        {
            if (!radioButton1.Checked & !radioButton2.Checked & !radioButton3.Checked & !radioButton4.Checked)
            {
                MessageBox.Show("Please Select A Difficulty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AIGame = true;
            PlayerGame = false;
            Winner = false;
            turncount = 0;
            foreach (Button button in groupBox2.Controls.OfType<Button>())
            {
                button.Text = String.Empty;
                button.Enabled = true;
                button.BackColor = Color.WhiteSmoke;
            }
            SetTurn();
            if (iturn == 0)
            {
                MessageBox.Show("Player 1 Goes First!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                turn = true;
            }
            else if (iturn == 1)
            {
                MessageBox.Show("AI Goes First!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                turn = false;
                AILogic();
            }
        }
        public void AILogic()
        {
            // Hard mode
            // 1. Win
            // 2. Block win
            // 3. Corner
            // 4. Center
            // 5. Any Space

            // Medium Mode
            // 1. Block Win
            // 2. Win
            // 3. Corner
            // 4. Any Space

            // Easy Mode
            // 1. Block Win
            // 2. Any space
            // 3. Corner
            // 4. Win
            GetButtons();
            if (Winner)
            {
                return;
            }
            if (difficulty == 3 | difficulty == 4)
            {
                move = checkforwinorblock(Turn.O.ToString());
                if (move == null)
                {
                    move = checkforwinorblock(Turn.X.ToString());
                    if (move == null)
                    {
                        move = lookforcorner();
                        if (move == null)
                        {
                            move = lookforopenspace();
                        }
                    }
                }
            }
            if (difficulty == 2)
            {
                move = checkforwinorblock(Turn.O.ToString());
                if (move == null)
                {
                    move = checkforwinorblock(Turn.X.ToString());
                    if (move == null)
                    {
                        move = lookforopenspace();
                        if (move == null)
                        {
                            move = lookforcorner();
                        }
                    }
                }
            }
            if (difficulty == 1)
            {
                move = checkforwinorblock(Turn.X.ToString());
                if (move == null)
                {
                    move = checkforwinorblock(Turn.O.ToString());
                    if (move == null)
                    {
                        move = lookforopenspace();
                        if (move == null)
                        {
                            move = lookforcorner();
                        }
                    }
                }
                
            }
            if (turncount < 9)
            {
                Thread.Sleep(2500);
                move.PerformClick();
                turn = true;
            }
        }
        public Button lookforopenspace()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, 9);
            if (Buttons[index] != null)
            {
                while (Buttons[index].Text != String.Empty)
                {
                    index = rnd.Next(0, 9);
                    if (Buttons[index].Text == String.Empty)
                    {
                        break;
                    }
                }
                return Buttons[index];
            }
            return null;
        }
        public Button checkforwinorblock(string player)
        {
            // horizontal checks
            if (bottomleft.Text == player && bottommiddle.Text == player && bottomright.Text == String.Empty)
            {
                return bottomright;
            }
            if (bottomright.Text == player && bottommiddle.Text == player && bottomleft.Text == string.Empty)
            {
                return bottomleft;
            }
            if (bottomleft.Text == player && bottomright.Text == player && bottommiddle.Text == string.Empty)
            {
                return bottommiddle;
            }
            // middle row
            if (secondleft.Text == player && secondmiddle.Text == player && secondright.Text == String.Empty)
            {
                return secondright;
            }
            if (secondright.Text == player && secondmiddle.Text == player && secondleft.Text == string.Empty)
            {
                return secondleft;
            }
            if (secondleft.Text == player && secondright.Text == player && secondmiddle.Text == string.Empty)
            {
                return secondmiddle;
            }
            // top row
            if (topleft.Text == player && topmiddle.Text == player && topright.Text == String.Empty)
            {
                return topright;
            }
            if (topright.Text == player && topmiddle.Text == player && topleft.Text == string.Empty)
            {
                return topleft;
            }
            if (topleft.Text == player && topright.Text == player && topmiddle.Text == string.Empty)
            {
                return topmiddle;
            }
            // vertical checks
            if (bottomleft.Text == player && secondleft.Text == player && topleft.Text == String.Empty)
            {
                return topleft;
            }
            if (bottomleft.Text == player && topleft.Text == player && secondleft.Text == String.Empty)
            {
                return secondleft;
            }
            if (topleft.Text == player && secondleft.Text == player && bottomleft.Text == string.Empty)
            {
                return bottomleft;
            }
            if (bottommiddle.Text == player && secondmiddle.Text == player && topmiddle.Text == string.Empty)
            {
                return topmiddle;
            }
            if (bottommiddle.Text == player && topmiddle.Text == player && secondmiddle.Text == String.Empty)
            {
                return secondmiddle;
            }
            if (topmiddle.Text == player && secondmiddle.Text == player && bottommiddle.Text == string.Empty)
            {
                return bottommiddle;
            }
            if (bottomright.Text == player && secondright.Text == player && topright.Text == string.Empty)
            {
                return topright;
            }
            if (bottomright.Text == player && topright.Text == player && secondright.Text == String.Empty)
            {
                return secondright;
            }
            if (topright.Text == player && secondright.Text == player && bottomright.Text == String.Empty)
            {
                return bottomright;
            }
            // diagonal checks
            if (bottomleft.Text == player && secondmiddle.Text == player && topright.Text == String.Empty)
            {
                return topright;
            }
            if (topright.Text == player && secondmiddle.Text == player && bottomleft.Text == string.Empty)
            {
                return bottomleft;
            }
            if (bottomleft.Text == player && secondmiddle.Text == string.Empty && topright.Text == player)
            {
                return secondmiddle;
            }
            if (topleft.Text == player && secondmiddle.Text == player && bottomright.Text == string.Empty)
            {
                return bottomright;
            }
            if (bottomright.Text == player && secondmiddle.Text == player && topleft.Text == string.Empty)
            {
                return topleft;
            }
            if (bottomright.Text == player && secondmiddle.Text == string.Empty && topleft.Text == player)
            {
                return secondmiddle;
            }
            return null;
        }
        public Button lookforcorner()
        {
            if (turncount == 0)
            {
                return Buttons[RandomCorner()];
            }
            if (turncount == 1)
            {            
                if (secondmiddle.Text != string.Empty)
                {
                    return Buttons[RandomCorner()];
                }
                if (bottomleft.Text != string.Empty | bottomright.Text != String.Empty | topright.Text != String.Empty | topleft.Text != String.Empty)
                {
                    if (difficulty == 4 | difficulty == 3)
                    {
                        return secondmiddle;
                    }
                    if (difficulty == 2)
                    {
                        return Buttons[RandomCorner()];
                    }
                    if (difficulty == 1)
                    {
                       move = lookforopenspace();
                    }
                }
            }
            if (turncount == 2)
            {
                if (difficulty == 4 | difficulty == 3)
                {
                    if (secondmiddle.Text == Turn.X.ToString())
                    {
                        if (Buttons[0].Text != string.Empty)
                        {
                            return Buttons[6];
                        }
                        if (Buttons[2].Text != string.Empty)
                        {
                            return Buttons[8];
                        }
                        if (Buttons[6].Text != string.Empty)
                        {
                            return Buttons[0];
                        }
                        if (Buttons[8].Text != string.Empty)
                        {
                            return Buttons[2];
                        }
                    }
                 
                }
                if (difficulty == 2 | difficulty == 1)
                {
                    Button corner = Buttons[RandomCorner()];
                    if (corner.Text != string.Empty)
                    {
                        corner = Buttons[RandomCorner()];
                        while (corner.Text != string.Empty)
                        {
                            if (corner.Text == string.Empty)
                            {
                                break;
                            }
                        }
                        return corner;
                    }
                }
                return null;
            }
            if (turncount == 3)
            {
                if (difficulty == 1 || difficulty == 2)
                {
                    Button corner = Buttons[RandomCorner()];
                    if (corner.Text != string.Empty)
                    {
                        corner = Buttons[RandomCorner()];
                        while (corner.Text != string.Empty)
                        {
                            if (corner.Text == string.Empty)
                            {
                                break;
                            }
                        }
                        return corner;
                    }
                    return corner;
                }
                if (difficulty == 3)
                {
                    if (secondmiddle.Text == String.Empty)
                    {
                        return secondmiddle;
                    }
                    if (secondmiddle.Text == Turn.X.ToString())
                    {
                        int spot = random_except_list(8, new int[] { 0, 2, 6, 8 });
                        if (Buttons[spot].Text != string.Empty)
                        {
                            while (Buttons[spot].Text != string.Empty)
                            {
                                spot = random_except_list(8, new int[] { 0, 2, 6, 8 });
                                if (Buttons[spot].Text == string.Empty)
                                {
                                    break;
                                }
                            }
                        }
                        return Buttons[spot];
                    }
                    return null;
                }
                if (difficulty == 4)
                {
                    if (secondmiddle.Text == String.Empty)
                    {
                        return secondmiddle;
                    }
                    if (secondmiddle.Text == Turn.X.ToString())
                    {
                        int spot = random_except_list(8, new int[] { 1, 3, 4, 5, 7 });
                        if (Buttons[spot].Text != string.Empty)
                        {
                            while (Buttons[spot].Text != string.Empty)
                            {
                                spot = random_except_list(8, new int[] { 1, 3, 4, 5, 7 });
                                if (Buttons[spot].Text == string.Empty)
                                {
                                    break;
                                }
                            }
                        }
                        return Buttons[spot];
                    }
                }
                return null;
            }        
            return null;   
        }
        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (AIGame)
            {
                if (turn == true)
                {
                    button.Font = new Font(button.Font.FontFamily, 48);
                    button.Text = Turn.X.ToString();
                    button.Enabled = false;
                    turncount++;
                }
                else if (!turn)
                {
                    button.Font = new Font(button.Font.FontFamily, 48);
                    button.Text = Turn.O.ToString();
                    button.Enabled = false;
                    turncount++;
                }
                turn = !turn;
                HighlightWinner();
                // horizontal checks
                CheckWinner(bottomleft.Text, bottommiddle.Text, bottomright.Text);
                CheckWinner(secondleft.Text, secondmiddle.Text, secondright.Text);
                CheckWinner(topleft.Text, topmiddle.Text, topright.Text);
                // vertical checks
                CheckWinner(bottomleft.Text, secondleft.Text, topleft.Text);
                CheckWinner(bottommiddle.Text, secondmiddle.Text, topmiddle.Text);
                CheckWinner(bottomright.Text, secondright.Text, topright.Text);
                // diagonal checks
                CheckWinner(bottomright.Text, secondmiddle.Text, topleft.Text);
                CheckWinner(bottomleft.Text, secondmiddle.Text, topright.Text);
                if (turncount == 9)
                {
                    if (CheckDraw())
                    {
                        MessageBox.Show("Game Was A Draw!", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ParseValues();
                        turncount = 0;
                        idraws = idraws + 1;
                        numdraws.Text = idraws.ToString();
                        NewGame();
                    }
                }
                   if ((!turn) && (AIGame))
                {
                    AILogic();
                }
                
                }
            if (PlayerGame)
            {
                if (iturn == 0)
                {
                    button.Font = new Font(button.Font.FontFamily, 48);
                    button.Text = Turn.X.ToString();
                    button.Enabled = false;
                    turncount++;
                    iturn = 1;
                }

                else if (iturn == 1)
                {
                    button.Font = new Font(button.Font.FontFamily, 48);
                    button.Text = Turn.O.ToString();
                    button.Enabled = false;
                    turncount++;
                    iturn = 0;
                }
                HighlightWinner();
                // horizontal checks
                CheckWinner(bottomleft.Text, bottommiddle.Text, bottomright.Text);
                CheckWinner(secondleft.Text, secondmiddle.Text, secondright.Text);
                CheckWinner(topleft.Text, topmiddle.Text, topright.Text);
                // vertical checks
                CheckWinner(bottomleft.Text, secondleft.Text, topleft.Text);
                CheckWinner(bottommiddle.Text, secondmiddle.Text, topmiddle.Text);
                CheckWinner(bottomright.Text, secondright.Text, topright.Text);
                // diagonal checks
                CheckWinner(bottomright.Text, secondmiddle.Text, topleft.Text);
                CheckWinner(bottomleft.Text, secondmiddle.Text, topright.Text);
                if (turncount == 9)
                {
                    if (CheckDraw())
                    {
                        MessageBox.Show("Game Was A Draw!", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ParseValues();
                        turncount = 0;
                        idraws = idraws + 1;
                        numdraws.Text = idraws.ToString();
                        NewGame();
                    }
                }
            }
        }
        // start game
        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartPlayerGame();
            foreach (Button button in groupBox2.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
        }
        // restart game
        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // disable buttons upon load
            foreach (Button button in groupBox2.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        // start game
        private void button1_Click(object sender, EventArgs e)
        {           
           DialogResult dialogResult = MessageBox.Show("Would You Like To Play Against AI?", "AI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (radioButton1.Checked)
                {
                    difficulty = 1;
                }
                else if (radioButton2.Checked)
                {
                    difficulty = 2;
                }
                else if (radioButton3.Checked)
                {
                    difficulty = 3;
                }
                else if (radioButton4.Checked)
                {
                    difficulty = 4;
                }
                StartAIGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                StartPlayerGame();
            }
        }
        // reset game
        private void button2_Click(object sender, EventArgs e)
        {
            if (AIGame)
            {
                StartAIGame();
            }
            else if (PlayerGame)
            {
                StartPlayerGame();
            }
        }
        // exit
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }  
}
