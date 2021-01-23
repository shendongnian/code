    public double SomeValue
    {
        get { return _SomeValue; }
        set
        {
            if (value < 0)
                _SomeValue = 0;
            else if (value >= 2)
                _SomeValue = 0;
            else
                _SomeValue = value;
            OnPropertyChanged("SomeValue");
        }
    }
    private double _SomeValue = 1;
