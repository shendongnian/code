    // The main entry point for the application.
    [STAThread]
    static void Main(string[] args)
    {
        // Parse input args
        var parser = new InputArgumentsParser();
        parser.Parse(args);
        ....
    }
