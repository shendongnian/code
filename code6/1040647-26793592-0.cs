    private static readonly IDictionary<int,Action<object>> processor =
        new Dictionary<int,Action<object>>
    {
        { 201, Process201 }
    ,   { 205, Process205 }
    };
    ...
    static void Process201(object message) {
        // Do something
    }
    static void Process205(object message) {
        // Do something else
    }
