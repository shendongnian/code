    private object _updateLock = new object();
    private void UpdateProc(object state)
    {
        if (!Monitor.TryEnter(_updateLock)) return;
        try
        {
            // poll and update
        }
        finally
        {
            Monitor.Exit(_updateLock);
        }
    }
