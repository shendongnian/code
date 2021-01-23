    private static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    private static Session _session = new Session();
    
    public static void Method1() {
        _lock.EnterReadLock();
        try {
            if(_session != null)
                _session.Action();
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }
    public static void Method2() {
        _lock.EnterReadLock();
        try {
            if(_session != null)
                _session.Action();
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }
    public static void Method3() {
        _lock.EnterReadLock();
        try {
            if(_session != null)
                _session.Action();
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }
    public static void Method4(string path) {
        _lock.EnterWriteLock();
        try {
            if(_session != null)
                _session.Action();
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
