     backgroundWorker1 = new BackgroundWorker();
     backgroundWorker1.WorkerReportsProgress = true;
     backgroundWorker1.DoWork+=backgroundWorker1_DoWork;
     backgroundWorker1.ProgressChanged+=backgroundWorker1_ProgressChanged;
     backgroundWorker1.RunWorkerAsync();
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
                int currentProgress = -1;
    
                decimal length=1000;
                while (currentProgress < length)
                {
                    currentProgress = Worker.progress;
                    backgroundWorker1.ReportProgress(currentProgress);
                    Thread.Sleep(500);
                    length = Worker.UrlList.Count;
                }
     }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)        {
                int ix = e.ProgressPercentage;
                progressBar1.Value = ix;
                lblText.Text = ix + " %";
    }
