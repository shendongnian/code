    public string S1
    {
        get { return _baseModel.S1; }
        set
        {
            if (_baseModel.S1 == value)
                return;
            baseModel.S1 = value;
            OnPropertyChanged("S1");
        }
    }
