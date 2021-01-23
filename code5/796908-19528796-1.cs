    public static void Main(string[] args)
    {
        if (args.Length == 1 && HelpRequired(args[0]))
        {
            DisplayHelp();
        }
        else
        {
            ...
        }
    }
    private static bool HelpRequired(string param)
    {
        return param == "-h" || param == "--help" || param == "/?";
    }
