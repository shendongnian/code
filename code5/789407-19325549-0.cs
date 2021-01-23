    public SplashScreen()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = false;
            lblLoading.Text = string.Empty;
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();            
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                for (int i = 1; i <= 20; i++)
                {
                    System.Threading.Thread.Sleep(200);
                    worker.ReportProgress(i);
                }
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string dots = string.Empty;
            for (int k = 1; k <= e.ProgressPercentage; k++)
            {
                dots = string.Format("{0}..",dots);
            }
            lblLoading.Text = ("Loading" + dots);
        }
