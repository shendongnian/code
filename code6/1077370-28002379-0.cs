    private readonly ObservableCollection<Order> _allOrders;
    private readonly ListCollectionView _filteredOrders;
    public ICollectionView FilteredOrders 
    { 
        get { return _filteredOrders; } 
    }
    
    public Presenter() 
    { 
        _allOrders = new ObservableCollection<Order>(...);
        _filteredOrders = new ListCollectionView(_allOrders); 
        _filteredOrders.Filter = o => ((Order)o).Active;
    }
