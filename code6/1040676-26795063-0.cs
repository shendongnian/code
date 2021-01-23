    {
        int Answer; // declares the Answer variable outside button event
        int Guesses = 0;     // declares counter outside button event
        public frmGuess()
        { // generates random number outside button event so does not change on button click
            InitializeComponent();
            Random rand = new Random(); 
            Answer = rand.Next(100) + 1; // makes it range 1 to 100
        }
        private void btnGuess_Click(object sender, EventArgs e)
        {
            int UserGuess;
            if (string.IsNullOrEmpty(txtGuess.Text)) // input validation check to make sure not blank and is a whole number integer
            {
                MessageBox.Show("Please enter a whole number between 1 and 100");
                return;
            }
            else
            {
                UserGuess = int.Parse(txtGuess.Text);  // variable assign and code run
                
                Guesses ++; // adds 1 to attempts but doesn't count textbox blank or mistyping
                
                if (UserGuess > Answer)
                {
                    txtGuess.Text = "";
                    lblAnswer.Text = "Too high, try again.";
                    Guesses++;
                }
                else if (UserGuess < Answer)
                {
                    txtGuess.Text = "";
                    lblAnswer.Text = "Too low, try again.";
                    Guesses++;
                }
                else
                {
                    lblAnswer.Text = "Congratulations the answer was " + Answer + "!\nYou guessed the number in " + Guesses + " tries.\nTo play again click the clear button.";
                }//end if
            } //end if
        } 
        private void btnClear_Click(object sender, EventArgs e)  // clears Answer label and Guess textbox
        {
            txtGuess.Text = "";
            lblAnswer.Text = "";
        }
        private void btnExit_Click(object sender, EventArgs e) // closes window
        {
            this.Close();
        }
    }
}
`
