    public void ResetView()
    {
        MyCollectionView = null;  // This is the key to making it work
        ICollectionView customerView = CollectionViewSource.GetDefaultView(_collection);
        customerView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        MyCollectionView = customerView;
    }
