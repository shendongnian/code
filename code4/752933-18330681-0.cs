    public MyClass MyClass
    {
        get
        {
            if(_myClass == null){ _myClass = new DefaultMyClass(); }
            return _myClass;
        }
        set
        {
            _myClass = value;
        }
    }
