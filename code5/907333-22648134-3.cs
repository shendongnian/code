    private static Dictionary<Type, IParser> parsers = new Dictionary<Type, IParser>();
    public static void Register<TResult, TParser>() 
        where TResult : struct 
        where TParser : IParser, new() 
    {
        parsers.Add(typeof(TResult), new TParser());
    }
    ...
    Register<bool, BoolParser>();
    Register<int, IntParser>();
