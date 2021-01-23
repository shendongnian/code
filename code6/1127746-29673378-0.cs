    public float Minuend
    {
        get
        {
            return _minuend;
        }
        set
        {
            if (_minuend == value) return;
            _minuend = value;
            NotifyPropertyChanged("Minuend");
            NotifyPropertyChanged("Difference");
        }
    }
    public float Subtrahend
    {
        get
        {
            return _subtrahend;
        }
        set
        {
            if (_subtrahend == value) return;
            _subtrahend = value;
            NotifyPropertyChanged("Subtrahend");
            NotifyPropertyChanged("Difference");
        }
    }
    public float Difference 
    {
        get
        {
            return Minuend - Subtrahend;
        }
    }
