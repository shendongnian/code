    static void Main()
    {
        ...
        var isFileFound = LookForSomeFiles();
        if (isFileFound)
            Application.Run(new MainForm());
    }
    private static bool LookForSomeFiles()
    {
        // perform your check
    }
