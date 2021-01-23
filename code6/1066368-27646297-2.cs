        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            if (e.ProgressPercentage >= 5)
            {
                worker.CancelAsync();
            }
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while(!worker.CancellationPending)
            {
                // TODO: do something.
                // TODO: update percentProgress 
                // backgroundWorker.ReportProgress(percentProgress);
            }
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }
