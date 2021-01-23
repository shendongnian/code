    public bool ContainsKey(TKey key)
    {
       bool result = false;
       WrapFunction(() => { result = MyDict.ContainsKey(key); });
       
       return result;
    }
    public void Clear()
    {
       WrapFunction(() => MyDict.Clear());
    }
    private void WrapFunction(Action<T> action)
    {
        bool IsLockTaken = false;
        try
        {
            // Acquire the lock:
            Monitor.TryEnter(SyncRoot, MonitorEnterTimeout, ref IsLockTaken);
            if (!IsLockTaken)
            {
                Log(@"Failed to Enter a monitor.");
                return;
            }
            action(); 
        }
        catch (System.Exception ex)
        {
            Log(String.Format("Error: {0}", ex.ToString()));
            return;
        }
        finally
        {
            if (IsLockTaken)
            {
                Monitor.Exit(SyncRoot);
            }
        } 
    }
