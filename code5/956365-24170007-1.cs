    // Constructor for SomeClass
    public SomeClass(object obj)
    {
        if(obj.GetType().IsPrimitive == false) throw new ArgumentException("obj");
    }
