    [DebuggerStepThrough]
    public static void Assert(bool condition)
    {
        if (!condition) Debugger.Break();
    }
        
    static void Main(string[] args)
    {
        Assert(false); // <-- break point here
        Console.ReadKey();
    }
