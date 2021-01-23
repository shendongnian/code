    public partial class Form1 : Form
    {
        BackgroundWorker bgw = new BackgroundWorker();
        Timer timer = new Timer();
        int count;
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
            count += 1;
            label1.Text = TimeSpan.FromSeconds(count).ToString();
        }
        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
 	        timer.Stop();
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(50000);
            //Put your email processing code here instead of the sleep
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bgw.RunWorkerAsync();
            timer.Start();
        }
    }
