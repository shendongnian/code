    public MyClass()
    {
    	List<T> list = //new list
    	_items = new ReadOnlyCollection<T>(list);    
    }
    private readonly IReadOnlyCollection<T> _items;
    public IReadOnlyCollection<T> Items
    {
    	get { return _items; }
    }
