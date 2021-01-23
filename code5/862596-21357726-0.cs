    public void myMethod(IEnumerable<T> enumerable)
    {
        if (typeof(IInterface).IsAssignableFrom(typeof(T))
        {
            // do one thing
        }
        else if (typeof(IAnotherInterface).IsAssignableFrom(typeof(T))
        {
            // do another thing
        }
    }
