        public partial class Form1 : Form
    {
        Random rand;
        int number;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rand = new Random();
            number = rand.Next(1, 100);
        }
        private void guessButton_Click(object sender, EventArgs e)
        {
            int userGuess;
            userGuess = int.Parse(guessText.Text);
            label2.Text = "" + number;
            if (userGuess > number)
            {
                resultLabel.Text = "Your guess is too high";
            }
            else if (userGuess < number)
            {
                resultLabel.Text = "Your guess is too low.";
            }
            else if (userGuess == number)
            {
                resultLabel.Text = "That is correct!";
            }
            guessText.Clear();
        }
        
    }
