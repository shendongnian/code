    private string[] _px = string[2];
    public string[] PX { get { return px; } }
    public string P1
    {
        get { return _px[0]; }
        set { _px[0] = value; }
    }
    public string P2
    {
        get { return _px[1]; }
        set { _px[1] = value; }
    }
