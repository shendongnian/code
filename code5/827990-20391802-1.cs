        BackgroundWorker bwEx = new BackgroundWorker();
        bwEx.DoWork += bwEx_DoWork;
        bwEx.RunWorkerCompleted += bwEx_RunWorkerCompleted;
        bwEx.ProgressChanged += bwEx_ProgressChanged;
        bwEx.WorkerReportsProgress = true;
        bwEx.RunWorkerAsync();
        private void bwEx_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           yourProgress.Value = e.ProgressPercentage;
        }
        private void bwEx_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
        private void bwEx_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
