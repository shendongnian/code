    public partial class PigForm : Form
    {
        Image[] diceImages;
        int dice;
        Random roll;
    
        private void rollDieBotton_Click(object sender, EventArgs e)
        {
            RollDice();
        }
    
        private void RollDice()
        {
            var currentRoll = roll.Next(1, 7);
            dice[i] += currentRoll;
            dicePictureBox.Image = diceImages[currentRoll-1];
            playersTotal.Text = String.Format("{0}", dice[i]);
        }
        private void PigForm_Load(object sender, EventArgs e)
        {
            diceImages = new Image[6];
            diceImages[0] = Properties.Resources.Alea_1;
            diceImages[1] = Properties.Resources.Alea_2;
            diceImages[2] = Properties.Resources.Alea_3;
            diceImages[3] = Properties.Resources.Alea_4;
            diceImages[4] = Properties.Resources.Alea_5;
            diceImages[5] = Properties.Resources.Alea_6;
            dice = 0;
            roll = new Random();
        }
    }
