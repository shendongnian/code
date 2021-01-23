    public void myMethod<T>(IEnumerable<T> enumerable)
    {
    	dynamic peek = enumerable.FirstOrDefault();
        Type dtype = peek.GetType();
    
        if (typeof(IInterface).IsAssignableFrom(dtype))
        {
            // do one thing
        }
        else if (typeof(IAnotherInterface).IsAssignableFrom(dtype))
        {
            // do another thing
        }
    }
