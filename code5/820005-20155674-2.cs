    public static void ProcessAllFilesUnderDirectory(string topLevelDirectory, string searchMask, Action<string> processFile)
    {
        var files = Directory.EnumerateFiles(topLevelDirectory, searchMask, SearchOption.AllDirectories);
        foreach (var file in files)
            processFile(file);
    }
    private static void ProcessAFile(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        // perform processing.
    }
    public static void Main(params string[] args)
    {
        ProcessAllFilesUnderDirectory(@"\camis01srfs04\DATA\Stats Analysis Project\Sobeys Stats\Atlantic", "*.txt", ProcessAFile);
    }
