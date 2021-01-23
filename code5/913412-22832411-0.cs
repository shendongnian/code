    public void SetName(string _name)
    {
        if (name == _name) // check
           return;   
    
        name = _name;
        isSomethingChanged = true;
    }
