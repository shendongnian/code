    public ObservableCollection<DbInfo> BookShelf
    {
        get
        {
            if (_BookShelf == null)
                _BookShelf = new ObservableCollection<DbInfo>();
            return _BookShelf;
        }
        set
        {
            if (value != _BookShelf)
            {   _BookShelf = value;
                RaisePropertyChanged(new PropertyChangedEventArgs("BookShelf"));
            }
        }
