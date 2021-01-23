    readonly List<MyItemClass> _myItems = new List<MyItemClass>();
    readonly object lockObject = new object();
    
    public IEnumerable<MyItemClass> MyItems
    {
        {
             return _myItems;  // or return _myItems.ToArray();
        }
    }
    
    public void Add(MyItemClass item)
    {
        lock(lockObject)
        {
            _myItems.Add(item);
        }
    }
    
    public bool Remove(MyItemClass item)
    {
        lock(lockObject)
        {
            return _myItems.Remove(item);
        }
    }
