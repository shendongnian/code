    private bool _locked;
    public string Name { get; private set;}
    public boolSetName(string value)
    {
        bool hasChanged = false;
        if(!_locked)
        {
            Name = value;
            _locked = true;
            hasChanged = true;
        }
        return hasChanged
    }
