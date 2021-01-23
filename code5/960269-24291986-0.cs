    private Visibility _loadScreenVisibility;
    public Visibility LoadScreenVisibility
    {
        get { return _loadScreenVisibility; }
        set
        {
            _loadScreenVisibility = value;
            OnPropertyChanged("LoadScreenVisibility");
        }
    }
