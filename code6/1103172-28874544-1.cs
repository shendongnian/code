    private readonly ObservableCollection<string> _list;
    public ViewModel()
    {
        _list = new ObservableCollection<string>();
    }
    public ObservableCollection<string> MyList
    {
        get { return _list; }
    }
    public void FillData()
    {
        // add any items you like to either _list or MyList,
        // because it's an observable collection, there's no
        // need to recreate the list, the view will be notified either way
    }
