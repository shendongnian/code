    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        //...
        e.Result = message;
    }
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        string message = e.Result as string;
        //...
    }
