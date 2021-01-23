    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
        private void Form1_Load(object sender, EventArgs e)
        {
            timerPro.Interval = 1000;
            timerPro.Tick +=new EventHandler(TimerEventHandler);
            SW.Start();
            timerPro.Start();
            bw.RunWorkerAsync();
        }
        private void TimerEventHandler(object sender, EventArgs e)
        {
            lblETA.Visible = true;
            TimeSpan TS = SW.Elapsed;
            string elapsed = String.Format("{0}:{1}:{2}", TS.Hours.ToString("00"), TS.Minutes.ToString("00"), TS.Seconds.ToString("00"));
            lblETA.Text = "Elapsed Time : " + elapsed;
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // ... do some work ...
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timerPro.Stop();
        }
    }
