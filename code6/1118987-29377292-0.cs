    public Product SalesCode
    {
        get { return _salesCode; }
        set 
        {
            _cond = null;
            _salesCode = value; 
        }
    }
    public ControlDate Condition
    {
        get { return _cond; }
        set 
        {
            _salesCode = null;
            _cond = value; 
        }
    }
