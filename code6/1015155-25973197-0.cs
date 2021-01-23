    private void BackgroundWorkerStartEvent(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void BackgroundWorkerCancelBeforeWorkIsDoneEvent(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation)
            {
                backgroundWorker1.CancelAsync();
            }
        }
        private void DoWorkEvent(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            const int loopnumber = 100;
            for (int i = 1; i <= loopnumber; i++)
            {
                if (worker != null && worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                System.Threading.Thread.Sleep(100);
                if (worker != null) worker.ReportProgress(i * 100/loopnumber);
            }
        }
        private void ProgressChangedEvent(object sender, ProgressChangedEventArgs e)
        {
           //...update your progress bar or something.
        }
        private void RunWorkerCompletedEvent(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //...Do what you do if the backgroundworker go cancelled...
            }
            else if (e.Error != null)
            {
                //...Error displaying...
            }
            else
            {
                //...Do what you do if it worked fine...
            }
        }
