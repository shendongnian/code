    private string _a; // a backing field
    public string a
    {
        get
        {
            return _a;
        }
        set
        {
            if (a != null) //some validation
                _a = value;
            else
                _a = string.Empty;
        }
    }
