    private ObservableCollection<MyType> _dataSource;
    public ObservableCollection<MyType> DataSource
    {
        get
        {
            if (this._dataSource == null)
            {
                this._dataSource = new ObservableCollection<MyType>();
            }
            return this._dataSource;
        }
        set { }
    }
    
    public string MyProperty 
    { 
        get
        {
            return this.SelectedItem.Title;
        } 
    }
    private MyType _selectedItem;
    public MyType SelectedItem
    { 
        get
        {
            return _selectedItem;
        } 
        set
        {
            _selectedItem = value;
            OnNotifyPropertyChanged("SelectedItem");
            OnNotifyPropertyChanged("MyProperty");
        }
    }
