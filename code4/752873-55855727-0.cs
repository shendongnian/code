    private Thread _backgroundWorkerThread;
    public void AbortBackgroundWorker()
    {
        if(_backgroundWorkerThread != null)
        _backgroundWorkerThread.Abort();
    }
    void DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
        _backgroundWorkerThread = Thread.CurrentThread;
        // call abd...
        }
        catch(ThreadAbortException)
        {
            // Do your clean up here.
        }
    }
