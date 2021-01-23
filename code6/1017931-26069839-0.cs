    public MyViewModel()
    {
        Purchases = new ObservableCollection<Purchase>();
        Purchases.CollectionChanged += Purchases_CollectionChanged;
    }
    private void Purchases_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
            foreach (Purchase item in e.NewItems)
                item.PropertyChanged += Purchase_PropertyChanged;
        if (e.OldItems != null)
            foreach (Purchase item in e.OldItems)
                item.PropertyChanged -= Purchase_PropertyChanged;
    }
    private void Purchase_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // save the xml...
    }
