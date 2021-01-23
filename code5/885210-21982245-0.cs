    public string Str
    {
        get { returns _str; }
        set
        {
            if (_str == value)
                return;
    
            _str = value;
            // custom logic
        }
    }
