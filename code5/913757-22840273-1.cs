    public class UI
    {
        private JobFile JobFile { get; set; }
        public int ProgressPercentage { get; set; }
        public void getMD5Hash()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += JobFile.bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This would have to run on dispatcher in order to update UI
            this.ProgressPercentage = e.ProgressPercentage;
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // If you need to do anything opn completion
        }
    }
