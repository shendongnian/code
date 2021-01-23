    private bool _red;
    public bool Red {
        get { return _red; }
        set 
        {
            _red = value;
            OnPropertychanged();
        }
    }
