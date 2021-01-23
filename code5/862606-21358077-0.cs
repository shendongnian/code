    public void myMethod(IEnumerable<dynamicT> enumerable)
    {
        Type dtype = enumerable.GetType().GetGenericArguments()[0];
    
        if (typeof(IInterface).IsAssignableFrom(dtype))
        {
            // do one thing
        }
        else if (typeof(IAnotherInterface).IsAssignableFrom(dtype))
        {
            // do another thing
        }
    }
