    public partial class Form1 : Form
    {
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // ... code ...
            for (int i = 0; i < 9; i++)   // populate the array  with 10 random values
            {
                int randomNumber = random.Next(1, 50);
                personalNumbers[i] = randomNumber.ToString();
            }
            // ... code ...
        }
    }
