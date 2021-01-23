    BackgroundWorker worker = new BackgroundWorker();
    worker.DoWork += worker_DoWork;
    worker.RunWorkerCompleted += worker_RunWorkerCompleted;
    worker.RunWorkerAsync("Name");
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        bool result = (bool)e.Result;
        //Do something with Result
    }
 
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
       e.Result = CheckForInternetConnection();
    }
