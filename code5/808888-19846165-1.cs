    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            NotifyPropertyChange(() => Name);
            NotifyPropertyChange(() => SaveEnabled);
        }
    }
    public bool SaveEnabled
    {
        get { return !string.IsNullOrEmpty(_name); }
    }
