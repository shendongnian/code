    public Double FontSize12
    {
        get
        {
             return _fontSize12;
        }
        set
        {
            _fontSize12 = value;
            put your logic!
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("FontSize12"));
        }
    }
