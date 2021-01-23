    static void Main(string[] args)
    {
        ParseArguments(args);
    }
    static void ParseArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                // Single arguments. (No sub-arguments)
                case "/a":
                case "/b":
                case "/c":
                    ParseArgument(args[i]);  // Parse individual argument(s)
                    break;
                // Double-arguments (1 sub-argument)
                case "/username":
                case "/password":
                case "/filepath":
                    string nextArg = (i + 1 < args.Length ? args[i + 1] : null);
                    ParseArgument(args[i], nextArg);  // Parse individual argument(s)
                    i++;
                    break;
                // Triple-arguments (2 sub-arguments)
                case "/makeAndModel":
                case "/nameAndAddress":
                    string nextArg = (i + 1 < args.Length ? args[i + 1] : null);
                    string nextArg2 = (i + 2 < args.Length ? args[i + 2] : null);
                    ParseArgument(args[i], nextArg, nextArg2);  // Parse individual argument(s)
                    i += 2;
                    break;
                // Invalid arguments
                default:
                    ShowHelp();
                    break;
        }
    }
    // Parse individual argument(s)
    static void ParseArgument(params string[] args)
    {
        ...
    }
