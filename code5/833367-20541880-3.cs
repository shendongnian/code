    System.Threading.ManualResetEvent _busy = new System.Threading.ManualResetEvent(false);
    void ResumeWorker() 
    {
         // Start the worker if it isn't running
         if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync(dataHolder);  
         // Unblock the worker 
         _busy.Set();
    }
    
    void PauseWorker() 
    {
        // Block the worker
        _busy.Reset();
    }
    
    void CancelWorker() 
    {
        if (backgroundWorker1.IsBusy) {
            // Set CancellationPending property to true
            backgroundWorker1.CancelAsync();
            // Unblock worker so it can see that
            _busy.Set();
        }
    }
