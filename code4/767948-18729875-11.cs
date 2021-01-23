    public void CancelWorker()
    {
       ContinueWorker();
       mainBackGroundWorker.CancelAsync();
    }
    private void mainBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        for (int i = 0; i < WebSitesToCrawl.Count; i++)
        {
            _busy.WaitOne();
             if ((worker.CancellationPending == true))
             {
                 e.Cancel = true;
                 break;
             }
             //...
        }  
    }
