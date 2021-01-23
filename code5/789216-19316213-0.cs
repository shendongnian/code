    public string Name1
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged("Name1");
        }
    }
    
