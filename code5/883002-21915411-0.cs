    public partial class Form1 : Form
    {
        private System.Timers.Timer _systemTimer = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _systemTimer = new System.Timers.Timer(500); 
            _systemTimer.Elapsed += _systemTimer_Elapsed;
        }
        void _systemTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            toolStripStatusLabel1.Text = string.Empty;
            _systemTimer.Stop(); // stop it if you don't want it repeating 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "random text just as an example";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _systemTimer.Start();
           
        }
    }
