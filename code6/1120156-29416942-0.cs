    public int GetData(int key)
    {
        //Note that this doesn't actually run VeryExpensiveComputationMethod 
        //until .Value is called on it
        var lazy = new Lazy<int>(() => VeryExpensiveComputationMethod(key));
        return values.GetOrAdd(key, lazy).Value;
    }
