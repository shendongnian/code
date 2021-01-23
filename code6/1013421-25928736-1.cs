    void MyMethod()
    {
        Task t = new Task(() =>{//Make my service call};
        t.Start();
        t.ContinueWith((sender) =>
        {
            //sort my data out
            //when thats done make another service call based on that data that doesn't
            // block UI thread
    
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }, cts.Token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
    }
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
         //do some stuff
    }
