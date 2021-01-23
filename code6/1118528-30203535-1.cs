    private HashSet<string> lockSet;
    private readonly object _lock = new object();
    public RefreshData(string key, Func<string, bool> cacheMissAction)
    {
        lock (_lock)
        {
            if (!lockSet.Add(key))
            {
                return;
            }
        }
        // if you are here means task was not already present
        cacheMissAction(key);
        lock (_lock)
        {
            lockSet.Remove(key);
        }
    }
