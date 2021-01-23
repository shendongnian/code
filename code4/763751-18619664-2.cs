    public ObservableCollection<MyObject> Collection
    {
        get { return _collection; }
        set 
        {
            _collection = value;
            RaisePropertyChangedEvent("Collection");
        }
    }
