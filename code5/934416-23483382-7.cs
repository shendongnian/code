    static void Main(string[] args)
    {
        int parsedCount = 0;
        for (int index = 0; index < args.Length; index += parsedCount)
        {
            parsedCount = ParseArguments(args);
        }
    }
    static int ParseArguments (string[] args, int index)
    {
        ...
    }
