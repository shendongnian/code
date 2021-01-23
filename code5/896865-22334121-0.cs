    private int _age;
    
    public int Age
    {
        get { return _age; }
        set
        {
            if (_age > 18)
                _age = value;
        }
    }
