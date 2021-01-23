        private void ScanClouds_FormClosing(object sender, FormClosingEventArgs e)
    {
        backgroundWorker2.WorkerSupportsCancellation = true;
        if (backgroundWorker2.IsBusy)
        {
            backgroundWorker2.CancelAsync();
    e.Cancel = true;
        }
        Terminate();
    }
