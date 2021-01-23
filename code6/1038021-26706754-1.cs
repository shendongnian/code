    // Property
    public int Property
    {
        get { return _field; }
        set { _field = value; }
    }
    // Property, albeit a get-only property
    public int Property => _field;
    // Method
    public int Method()
    {
        return _field;
    }
    // Method
    public int Method() => _field;
