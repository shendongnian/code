    private void AsyncOperationCompleted(object arg)
    {
        isRunning = false;
        cancellationPending = false;
        OnRunWorkerCompleted((RunWorkerCompletedEventArgs)arg);
    }
    public bool IsBusy
    {
        get
        {
            return isRunning;
        }
    }
