    BackgroundWorker bwEx = new BackgroundWorker();
    bwCheckingFileDrop.DoWork += bwEx_DoWork;
    bwCheckingFileDrop.RunWorkerCompleted += bwEx_RunWorkerCompleted;
    bwCheckingFileDrop.ProgressChanged += bwEx_ProgressChanged;
    bwCheckingFileDrop.WorkerReportsProgress = true;
    bwCheckingFileDrop.RunWorkerAsync();
        private void bwCheckingFileDrop_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           yourProgress.Value = e.ProgressPercentage;
        }
        private void bwCheckingFileDrop_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
        private void bwCheckingFileDrop_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
