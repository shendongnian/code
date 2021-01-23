     public Test()
        {
            this.InitializeComponent();
            BackgroundWorker backgroundWorker = new BackgroundWorker
                {
                    WorkerReportsProgress = true
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
            while (true)
            {
                //Do your stuff here
                ((BackgroundWorker)sender).ReportProgress(0, "AN OBJECT TO PASS TO THE UI-THREAD");
            }
        }
