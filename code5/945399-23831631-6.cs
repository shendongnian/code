    static void Main(string[] args)
    {
        int callCount = 0;
        AlwaysEmit(++callCount);
        VerboseEmit(++callCount);
        DebugEmit(++callCount);
        Console.WriteLine("Call count = " + callCount);
        Console.ReadLine();
    }
