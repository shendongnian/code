    ObservableCollection<T> internalCollection = new ObservableCollection<T>();
    //implement collection methods as forwards to internalCollection EXCEPT the changed event
    public event NotifyCollectionChangedEventHandler CollectionChanged;
    public MyObservableCollection()
    {
        internalCollection.CollectionChanged += (s, e) => CollectionChanged(s, e);
    }
