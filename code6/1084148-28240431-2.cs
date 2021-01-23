    public bool IsAwake
    {
        get
        {
            return _isAwake;
        }
        set
        {
            if (_isAwake != value)
            {
                _isAwake = value;
                // raise PropertyChanged event for *both* IsAwake and IsAsleep
            }
        }
    }
    bool _isAwake;
    public bool IsAsleep
    {
        get
        {
            return !_isAwake;
        }
    }
