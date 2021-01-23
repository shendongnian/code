    private static void ReadAllFilesStartingFromDirectory(string topLevelDirectory)
    {
        const string searchPattern = "*.txt";
        var subDirectories = Directory.EnumerateDirectories(topLevelDirectory);
        foreach (string subDirectory in subDirectories) 
            ReadAllFilesStartingFromDirectory(subDirectory);
        var filesInDirectory = Directory.EnumerateFiles(topLevelDirectory, searchPattern);
        IterateFiles(filesInDirectory, topLevelDirectory);
    }
    private static void IterateFiles(IEnumerable<string> files, string directory)
    {
        int counter = 0;
        foreach (var file in files)
        {
            var filelines = File.ReadAllLines(file) 
            //and execute code;
        }
    }
