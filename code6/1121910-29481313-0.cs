    public static Response Query<T>(ref R1 @out)
    {
        @out = Logic(() => method());
    }
    
    public static Response Query<T>(F<> a, ref R1 @out)
    {
        @out = Logic(() => method(a));
    }
    
    public static Response Query<T>(F<> a, F<> b, ref R1 @out)
    {
        @out = Logic(() => method(a, b));
    }
    
    ...
    
    public static R1 Logic(Func<R1> doMethod)
    {
        R1 @out;
        // logic
        if(true) { @out = doMethod(); }
        ...
        
        return @out;
    }
