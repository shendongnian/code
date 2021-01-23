    public static Response Query<R1>(Func<R1> method, ref R1 @out)
    {
        @out = Logic(() => method());
    }
    
    public static Response Query<T1, R1>(Func<T1, R1> method, T1 a, ref R1 @out)
    {
        @out = Logic(() => method(a));
    }
    
    public static Response Query<T1, T2, R1>(Func<T1, T2, R1> method, T1 a, T2 b, ref R1 @out)
    {
        @out = Logic(() => method(a, b));
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
