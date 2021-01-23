    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            NotifyPropertyChanged(() => Name);
            NotifyPropertyChanged(() => SaveEnabled);
        }
    }
    public bool SaveEnabled
    {
        get { return !string.IsNullOrEmpty(_name); }
    }
