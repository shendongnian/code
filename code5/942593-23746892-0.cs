    get { return _authenticateStatus; }
    set
    {
        if (_authenticateStatus != value)
        {
            _authenticateStatus = value;
            OnPropertyChanged("AuthenticateStatus");
        }
    }
