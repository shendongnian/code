    namespace Number_guessing_game
    {
    public partial class Form1 : Form
    {
        public int montH;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myFunction(montH);      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             montH=0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
        Random rnd = new Random();
        montH = rnd.Next(1, 10);
        }
        void myFunction(montH)
        {
            int guess = int.Parse(textBox1.Text);
            if (guess == montH)
            {
                MessageBox.Show("You win!");
            }
            if (guess != montH)
            {
                MessageBox.Show("You lose!");
            }
        }
    }
}
