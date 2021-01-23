    OInterface obj = null;
    
    public Omega(int type)
    {
        if(type == 1)
            obj = new Alpha();
        else if (type == 2)
             obj = new Beta();
        else
             throw new ArgumentException("Wrong type provided: " + type, "type");
    }
