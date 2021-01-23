    MyValue _myProperty;
    public MyValue MyProperty
    {
        get { return _myProperty; }
        set
        {
            // check constraints in setter
            if(value != null && ... )
               ... // do something
            _myProperty = value;
        }
    }
