    public ICollectionView MyList
    {
        get
        {
            if(_mylist == null)
                _mylist = CollectionViewSource.GetDefaultView(observableCollection);
            return _mylist;
        }
    }
