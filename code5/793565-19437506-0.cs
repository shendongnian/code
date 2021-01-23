        int randomNumber;
        Random random;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void buttonCheckGuess_Click(object sender, EventArgs e)
        {
            
            randomNumber = random.Next(0, 10);
            if (Convert.ToInt32(textboxGuess.Text) == randomNumber)
            {
                MessageBox.Show("Your Guessed Correctly! The Number Is: " + textboxGuess.Text);
            }
            else if (Convert.ToInt32(textboxGuess.Text) < randomNumber)
            {
                MessageBox.Show("The Number Is Larger Than: " + textboxGuess.Text);
            }
            else if (Convert.ToInt32(textboxGuess.Text) > randomNumber)
            {
                MessageBox.Show("The Number Is Smaller Than: " + textboxGuess.Text);
            }
            else
            {
                MessageBox.Show("Your Guessed Incorrectly. The Random Number Is Not: " + textboxGuess.Text);
            }
        }
    }
