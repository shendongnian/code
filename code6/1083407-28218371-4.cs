    public ICollectionView MyCollectionView
    {
        get
        {
            return _myCollectionView;
        }
        set
        {
            _myCollectionView = value;
            OnPropertyChanged("MyCollectionView");
        }
    }
    ICollectionView _myCollectionView;
