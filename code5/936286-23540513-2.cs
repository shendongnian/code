    public void YourLongRunningMethod(IProgressObserver progressObserver)
    {
        // ...
    
        progressObserver.NotifyProgress(1d);
    }
