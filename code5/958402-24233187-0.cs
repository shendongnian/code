    ...
    private DateTime _dt_get;    
    
    public DateTime dt_get
    {
        get { return _dt_get; }
        set { value = _dt_get; }  // <-- !!! insted of set { _dt_get = value; }
    }
    
    ...
