    public IEnumerable<Item> Collection 
    {
        get { ... }
        set
        {
            //store the value in the backing field
            if (value != null)
            {
                CollectionView = CollectionViewSource.GetDefaultView(value);
                CollectionView.SortDescriptions.Add(new SortDescription
                {
                    Direction = ListSortDirection.Ascending,
                    PropertyName = "SortOrder",
                });
            }
            else
                CollectionView = null;
        }
    }
    public ICollectionView CollectionView
    {
        get { ... }
        set
        {
            //store the value in the backing field and raise PropertyChanged
        }
    }
