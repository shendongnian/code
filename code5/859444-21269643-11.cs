    const string CacheKey = "CacheKey";
    static readonly ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
    static string GetCachedData()
    {
        //First we do a read lock to see if it already exists, this allows multiple readers at the same time.
        cacheLock.EnterReadLock();
        try
        {
            //Returns null if the string does not exist, prevents a race condition where the cache invalidates between the contains check and the retreival.
            var cachedString = MemoryCache.Default.Get(CacheKey, null) as string;
            if (cachedString != null)
            {
                return cachedString;
            }
        }
        finally
        {
            cacheLock.ExitReadLock();
        }
        //Only one UpgradeableReadLock can exist at one time, but it can co-exist with many ReadLocks
        cacheLock.EnterUpgradeableReadLock();
        try
        {
            //We need to check again to see if the string was created while we where waiting to enter the EnterUpgradeableReadLock
            var cachedString = MemoryCache.Default.Get(CacheKey, null) as string;
            if (cachedString != null)
            {
                return cachedString;
            }
            //The entry still does not exist so we need to create it and enter the write lock
            var expensiveString = SomeHeavyAndExpensiveCalculation();
            cacheLock.EnterWriteLock(); //This will block till all the Readers flush.
            try
            {
                CacheItemPolicy cip = new CacheItemPolicy()
                {
                    AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(20))
                };
                MemoryCache.Default.Set(CacheKey, expensiveString, cip);
                return expensiveString;
            }
            finally 
            {
                cacheLock.ExitWriteLock();
            }
        }
        finally
        {
            cacheLock.ExitUpgradeableReadLock();
        }
    }
