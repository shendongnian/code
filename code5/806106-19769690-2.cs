     public Test()
        {
            this.InitializeComponent();
            BackgroundWorker backgroundWorker = new BackgroundWorker
                {
                     WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
            backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            backgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;
        }
        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object userObject = e.UserState;
            int percentage = e.ProgressPercentage;
        }
        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker) sender;
            while (!worker.CancellationPending)
            {
                //Do your stuff here
                worker.ReportProgress(0, "AN OBJECT TO PASS TO THE UI-THREAD");
            }        
        }
    
