    private ConcurrentDictionary<string, ulong> _domainNames = new ConcurrentDictionary<string, ulong>();
    
    public void ShowData(ref DataGridView dmRequests)
    {
        dmRequests.DataSource = _domainNames.OrderBy(x => x.Key);  //Set the current values of the dictionary to the grid.
    }
    public void MultiThreadedMethod()
    {
        _domainNames.TryAdd(someKey, someValue);  //Access the dictionary from multiple threads.
    }
