    private bool _drawEnabled = false;
    public bool DrawEnabled 
    {
        get { return _drawEnabled; }
        set { _drawEnabled=value; Draw(); }
    }
