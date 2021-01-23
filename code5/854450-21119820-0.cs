    public string FirstName
    {
        get { return _firstName; }
        set
        {
            _firstName= value;
            NotifyPropertyChanged("FirstName");
            NotifyPropertyChanged("Initial");
        }
    }
