    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Random _random = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = random .Next(0,500);
            int y = random .Next(0,500);
            pictureBox1.Top += y;
            pictureBox1.Left += x;
        }
    }
