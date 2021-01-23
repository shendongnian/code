    public void SetStorageProviderFor<T>() where T : class
    {
        var local = Set<T>().Local;
        local.CollectionChanged -= SetChanged;
        local.CollectionChanged += SetChanged;
    }
    
    private void SetChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        foreach (var item in args.NewItems)
        {
            // set storage provider for an entity instance
        }
    }
