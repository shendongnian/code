    void WaitForExit()
    {
        lock (mylock) ;
        // exited
    }
    void bool IsExited()
    {
        bool lockTacken = false;
        try
        {
            Monitor.TryEnter(mylock, ref lockTacken);
        }
        finally
        {
            if (lockTacken)
            {
                Monitor.Exit(mylock);
            }
        }
        return lockTacken;
    }
