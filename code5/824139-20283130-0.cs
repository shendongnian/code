    BackgroundWorker bgw;
    private void btnScrape_Click(object sender, EventArgs e)
    {
      bgw = new BackgroundWorker();
      bgw.WorkerReportsProgress = true;
      bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
      bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
      bgw.RunWorkerAsync();
    }
    
    void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
      for (int i = 1; i <= 100; i++)
      {
        Thread.Sleep(100);
        bgw.ReportProgress(i);
      }
    }
    
    private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar1.Value = e.ProgressPercentage;
    }
