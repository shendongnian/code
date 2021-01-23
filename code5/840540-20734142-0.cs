    private void WelcomeScreen_Load(object sender, EventArgs e)
    {
        var worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.DoWork += worker_DoWork;
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        worker.ProgressChanged += worker_ProgressChanged;
        worker.RunWorkerAsync();
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var percentComplete = e.ProgressPercentage;
        var userState = (string)e.UserState;
        //do something with these values, like moving your progress bar
    }
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // do something when the worker completes, like start your timer
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        // do the "work" for the background worker
          
        var currentWorker = (BackgroundWorker)sender;
        currentWorker.ReportProgress(0, "Just Starting");
        // do your first task
        currentWorker.ReportProgress(25, "Finish First Task");
        // ...
    }
