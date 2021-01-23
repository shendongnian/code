    public int MyProperty { get; private set; } // can get but not set
    private int myVar; 
    public int MyProperty
    {
        get { return myVar; } // same as the top but with a field
    }
