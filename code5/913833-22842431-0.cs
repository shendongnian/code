    public bool IsValid
    {
        get { return _isValid; }
        set
        {
            if (_isValid != value)
            {
                _isValid = value;
                OnPropertyChanged("IsValid");
            }
        }
    }
