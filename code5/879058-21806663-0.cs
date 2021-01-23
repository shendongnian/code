    public partial class Form1 : Form
    {
        int guessNumber;
        int rndNumber;
        int userNumber;
        public Form1()
        {
            InitializeComponent();
            //Generates random number for game
            Random rnd = new Random();
            rndNumber = rnd.Next(101);
            this.number.Text = rndNumber.ToString();
        }
        
       
        //does this when evaluate button is clicked        
        private void evaluate_Click(object sender, EventArgs e)
        {
            //counter for the number of guesses
            
            if (string.IsNullOrWhiteSpace(this.guess.Text))
            {
                MessageBox.Show("Must enter a number 0-100 to play");
                // while (!string.IsNullOrEmpty(this.guess.Text))
                // {
                // guessNumber++;
                // }
            }
            else
            {
                guessNumber++;
                userNumber = Convert.ToInt32(guess.Text);
                if (userNumber == rndNumber)
                {
                    MessageBox.Show("you took these many guesses = "+guessNumber.ToString());
                }
                else
                {
                    MessageBox.Show("Invalid Guess Try Again!!!");
                }
            }
        }
        //Makes sure user only enters numbers 0-100
        private void guess_TextChanged(object sender, EventArgs e)
        {
            var userInput=Convert.ToInt32(guess.Text);
            if (!(userInput > 0 && userInput <= 100))
            {
                MessageBox.Show("enter number between 1 and 100");
                guess.Text = userInput.ToString().Substring(0, userInput.ToString().Length - 1);
            }
        }
    }
