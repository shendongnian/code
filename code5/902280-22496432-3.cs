    public Double FontSize
    {
        get
        {
             return _fontSize;
        }
        set
        {
            _fontSize = value;
            put your logic!
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("FontSize"));
        }
    }
