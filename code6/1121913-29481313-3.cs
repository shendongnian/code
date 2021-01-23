    public static Response Query<R1>(Func<Tuple<Result, R1>> method, ref R1 @out)
    {
        Tuple<Result, R1> result = Logic(() => method());
        @out = result.Item2;
        return result.Item1;
    }
    
    public static Response Query<T1, R1>(Func<T1, Tuple<Result, R1>> method, T1 a, ref R1 @out)
    {
        Tuple<Result, R1> result = Logic(() => method(a));
        @out = result.Item2;
        return result.Item1;
    }
    
    public static Response Query<T1, T2, R1>(Func<T1, T2, Tuple<Result, R1>> method, T1 a, T2 b, ref R1 @out)
    {
        Tuple<Result, R1> result = Logic(() => method(a, b));
        @out = result.Item2;
        return result.Item1;
    }
    
    ...
    
    public static Tuple<Result, R1> Logic<R1>(Func<Tuple<Result, R1>> doMethod)
    {
        Tuple<Result, R1> result;
        // logic
        if(true) { result = doMethod(); }
        ...
        
        // watch out if this doesn't get assigned, can cause problems downstream
        return result;
    }
