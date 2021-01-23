	private ReaderWriterLockSlim synclock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
	
	public T GetOrAdd(string key, Func<T> loadFunction)
	{
		LazyLock lazy;
		bool success;
		synclock.EnterReadLock();
		try
		{
			success = this.cacheProvider.TryGetValue(key, out lazy);
		}
		finally
		{
			synclock.ExitReadLock();
		}
		if (!success)
		{
			synclock.EnterWriteLock();
			try
			{
				if (!this.cacheProvider.TryGetValue(key, out lazy))
				{
					lazy = new LazyLock();
					this.cacheProvider.Add(key, lazy);
				}
			}
			finally
			{
				synclock.ExitWriteLock();
			}
		}
		return lazy.Get(loadFunction);
	}
	
    private sealed class LazyLock
    {
        private volatile bool got;
        private object value;
        public TValue Get<TValue>(Func<TValue> activator)
        {
            if (!got)
            {
                if (activator == null)
                {
                    return default(TValue);
                }
                lock (this)
                {
                    if (!got)
                    {
                        value = activator();
                        got = true;
                    }
                }
            }
            return (TValue)value;
        }
    }
