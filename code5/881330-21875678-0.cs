        public Form1()
        {
            bw = new BackgroundWorker();
            bw.RunWorkerCompleted += OnCompleted;
        }
        private BackgroundWorker bw;
        private AutoResetEvent completed = new ManualResetEvent(false);
        private void OnCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            completed.Set();
        }
        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (bw.IsBusy)
            {
                bw.CancelAsync();
                completed.WaitOne();
            }
            //do a lot of stuff
            completed.Reset();
            bw.RunWorkerAsync();
        }
