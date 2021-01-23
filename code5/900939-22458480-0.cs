    private SomeType field
    
    public SomeType Property
    {
        get
        {
            return Volatile.Read(ref field);
        }
        set
        {
            Volatile.Write(ref field, value);
        }
    }
