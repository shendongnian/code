        public int ProgressPercentage { get; set; }
        public void getMD5Hash()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            StringBuilder hash = new StringBuilder();
            for (int i = 1; (i <= 10); i++)
            {
                // Perform a time consuming operation and report progress.
                // Such as computing part of the hash.
                hash.Append(i);
                //Report progress here
                worker.ReportProgress((i*10)); // 
            }
            e.Result = hash.ToString();
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This would have to run on dispatcher in order to update UI
            this.ProgressPercentage = e.ProgressPercentage;
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.MD5Hash = e.Result as string;
        }
