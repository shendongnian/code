    public static Response Query<R1>(ref R1 @out)
    {
        @out = Logic(() => Method());
    }
    
    public static Response Query<T1, R1>(T1 a, ref R1 @out)
    {
        @out = Logic(() => Method(a));
    }
    
    public static Response Query<T1, T2, R1>(T1 a, T2 b, ref R1 @out)
    {
        @out = Logic(() => Method(a, b));
    }
    
    ...
    
    public static R1 Logic<R1>(Func<R1> doMethod)
    {
        R1 @out;
        // logic
        if(true) { @out = doMethod(); }
        ...
        
        return @out;
    }
