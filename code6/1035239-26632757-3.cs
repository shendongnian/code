    public MyViewModel()
    {
        WatchListCollection = new ObservableCollection<WatchListModel>();
        // Hook up initial changed handler. Could also be done in setter
        WatchListCollection.CollectionChanged += WatchListCollection_CollectionChanged;
    }
    
    void WatchListCollection_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
        // if new itmes get added, attach change handlers to them
        if (e.NewItems != null)
            foreach(WatchListModel item in e.NewItems)
                item.PropertyChanged += WatchListModel_PropertyChanged;
    
        // if items got removed, detach change handlers
        if (e.OldItems != null)
            foreach(WatchListModel item in e.OldItems)
                item.PropertyChanged -= WatchListModel_PropertyChanged;
        // Process Add/Remove here
    }
    
    void WatchListModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // Process Update here
    }
