    public string customerName
    {
        get
        {
            return _customerName;
        }
        set
        {
            if (_customerName == value)
                return;
            _customerName = value;
            RaisePropertyChanged("customerName");
        }
    }
