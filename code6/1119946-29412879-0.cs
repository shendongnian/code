        private void button1_Click(object sender, EventArgs e)
        {
            int ProgressToBeupdated = 100;
            BackgroundWorker WorkerThread = new BackgroundWorker();
            WorkerThread.WorkerReportsProgress = true;
            WorkerThread.DoWork += WorkerThread_DoWork;
            WorkerThread.ProgressChanged += WorkerThread_ProgressChanged;
            WorkerThread.RunWorkerAsync(new object());
            
        }
        void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
                (sender as BackgroundWorker).ReportProgress(i);       
            }
        }
