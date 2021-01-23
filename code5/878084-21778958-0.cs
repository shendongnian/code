    public God() {
        Believers  = new ObservableCollection<T>();
        Believers.CollectionChanged += BelieversListChanged;
    }
    private void BelieversListChanged(object sender, NotifyCollectionChangedEventArgs args) {
       // list changed
    }
