    public partial class Form1 : Form
    {
        BackgroundWorker bgw = new BackgroundWorker();
        Timer timer = new Timer();
        DateTime startTime;
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerCompleted+=bgw_RunWorkerCompleted;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            label1.Text =((TimeSpan)DateTime.Now.Subtract(startTime)).ToString("mm\\:ss");
        }
        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
 	        timer.Stop();
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int I = 0 ; I <= messages.count() - 1; I++)
            {
                //process emails
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bgw.RunWorkerAsync();
            startTime = DateTime.Now;
            timer.Start();
        }
    }
