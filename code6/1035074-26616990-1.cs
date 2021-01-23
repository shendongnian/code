    public void BW_DoWork(object sender, DoWorkEventArgs e)
    {
        /// run infinitely
        while (true)
        {
            /// add your code to be executed every 3 seconds here
            Thread.Sleep(3000);
        }
    }
    /// uses System.ComponentModel
    BackgroundWorker backgroundWorker = new BackgroundWorker() { WorkerReportsProgress = true };
    backgroundWorker.DoWork += BW_DoWork;
    backgroundWorker.RunWorkerAsync();
