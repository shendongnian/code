    private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    public void DoRead(string xyz)
    {
        try
        {
            _lock.EnterReadLock();
            // whatever
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }
    public void DoWrite(string xyz)
    {
        try
        {
            _lock.EnterWriteLock();
            // whatever
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
