    StarTransaction()
    {
        if (!Monitor.TryEnter(syncRoot, new TimeSpan(0, 0, 0, 10)))
            throw new TimeoutException("Transaction is busy, Try Again in some seconds");
        // if we are here, then lock was successfully taken
        try
        {
            mCompany.StartTransaction();
        }
        finally
        {
            Monitor.Exit(syncRoot);
        }
    }
