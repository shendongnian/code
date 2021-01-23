    var lock = new ReaderWriterLockSlim();
    
    Parallel.Foreach(items, (item, state) =>
    {
        lock.EnterReadLock();
        try {
            Task1(item);
        } finally {
            lock.ExitReadLock()
        }
        lock.EnterWriteLock();
        try {
            Task2(item);
        } finally {
            lock.ExitWriteLock()
        }
    }
