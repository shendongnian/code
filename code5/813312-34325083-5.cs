    public void EnsureInitialized()
    { 
        if (_initialized)
        {
            return;
        }
        _initialized = true;
        Initializer(this);            
    }
