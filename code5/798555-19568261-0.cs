    private readonly ConcurrentDictionary<string, string> _items
        = new ConcurrentDictionary<string, string>();
    
    public void MyMethod(string item, string value)
    {
        _items.AddOrUpdate(item, value, (i, v) => value);
    }
