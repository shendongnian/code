    public bool ContainsKey(TKey key)
    {
       return WrapFunction(() => MyDict.ContainsKey(key));
    }
    private T WrapFunction(Func<T> func)
    {
        bool IsLockTaken = false;
        try
        {
            // Acquire the lock:
            Monitor.TryEnter(SyncRoot, MonitorEnterTimeout, ref IsLockTaken);
            if (!IsLockTaken)
            {
                Log(@"Failed to Enter a monitor.");
                return false;
            }
            return func(); 
        }
        catch (System.Exception ex)
        {
            Log(String.Format("Error: {0}", ex.ToString()));
            return false;
        }
        finally
        {
            if (IsLockTaken)
            {
                Monitor.Exit(SyncRoot);
            }
        } 
    }
