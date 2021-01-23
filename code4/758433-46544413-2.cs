    public ICollectionView TableDataWrapper
    {
        get { return this.tableDataWrapper; }
        set
        {
            this.tableDataWrapper = value;
            OnPropertyChanged("TableDataWrapper");
        }
    }
