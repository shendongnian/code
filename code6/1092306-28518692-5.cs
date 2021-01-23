    private readonly PropertyChangedEventHandler reusablePropertyChangeDelegate;
    private readonly InstanceChangedEventHandler reusableInstanceChangedDelegate;
    public MyCollectionPropertyObserver(IObservableList collection)
    {
        reusablePropertyChangeDelegate = PropertyChanged;
        reusableInstanceChangeDelegate = InstanceChanged;
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
            propChange.PropertyChanged += reusablePropertyChangeDelegate;
        var instChanged = entity as INotifyInstanceChanged;
        if (instChanged != null)
            instChanged.InstanceChanged += reusableInstanceChangeDelegate;
    }
