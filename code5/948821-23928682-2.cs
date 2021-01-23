    private string _myProperty;
    public string MyProperty
    {
        get { return _myProperty != null ? _myProperty : string.Empty; }
        set { _myProperty = value; }
    }
    
