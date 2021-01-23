    private ICollectionView _customerView;
 
    public ICollectionView Customers
    {
        get { return _customerView; }
    }
 
    public CustomerViewModel()
    {
        IList<YourClass> customers = ServiceManager.Instance.ActiveObjects;
        _customerView = CollectionViewSource.GetDefaultView(customers);
    }
...
    <ListBox ItemsSource="{Binding Customers}" />
