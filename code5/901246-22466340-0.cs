        ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
        get
        {
            _rw.EnterReadLock();
            SomeType result = field;
            _rw.ExitReadLock();
            return result;
        }
        set
        {
            _rw.EnterWriteLock();
            field = value;
            _rw.ExitWriteLock();
        }
