    void ResumeWorker() 
    {
         // Start the worker if it isn't running
         if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();  
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
