    public MyCollectionPropertyObserver(IObservableList collection)
    {
        _sourceCollection = collection;
        _sourceCollection.CollectionChanged += WeakEventHandler.Wrap(CollectionChanged, eh => _sourceCollection.CollectionChanged -= eh);
        Subscribe(_sourceCollection);
    }
    private void Subscribe(object entity)
    {
        if (entity == null) return;
        if (_subscribedItems.Contains(entity))
            return;
        _subscribedItems.Add(entity);
        var propChange = entity as INotifyPropertyChanged;
        if (propChange != null)
            propChange.PropertyChanged += PropertyChanged; // creates a new delegate object, wasteful!
        var instChanged = entity as INotifyInstanceChanged;
        if (instChanged != null)
            instChanged.InstanceChanged += InstanceChanged; // same problem, wasteful!
    }
