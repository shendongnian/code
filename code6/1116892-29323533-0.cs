    protected override void InsertItem(int index, IModuleCatalogItem item)
    {
        base.InsertItem(index, item);
        this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
    }
