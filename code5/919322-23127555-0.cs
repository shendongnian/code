    public int Type
    {
        get { return _type; }
        set
        { 
            _type = value;
            OnPropertyChanged("Type");
            ChangeType(value);
        }
    }
