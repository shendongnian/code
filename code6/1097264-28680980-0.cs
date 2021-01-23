    public partial class Form1 : Form
    {
        int difference = 0;
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 15;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += difference;
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            difference = -2;
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            difference = 2;
        }
    }
