    public partial class Form1 : Form
    {
        private Timer pbTimer;
        private int pbProgress = 0;
        public Form1()
        {
            InitializeComponent();
            pbTimer = new Timer();
            pbTimer.Tick += new EventHandler(ProgressUpdate);
            pbTimer.Interval = 20;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
        }
        private void ProgressUpdate(object sender, EventArgs e)
        {
            if (pbProgress < 100)
            {
                progressBar1.Value = ++pbProgress;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            pbTimer.Start();
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pbTimer.Stop();
            progressBar1.Value = 0;
            pbProgress = 0;
        }
