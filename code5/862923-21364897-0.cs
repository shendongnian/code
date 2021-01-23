    public static DirSearch(string dir, string pattern)
    {
        List<string> files = new List<string>();
        DirSearchImpl(dir, pattern, files);
        File.WriteAllLines("files.txt", files);
    }
    private static DirSearchImpl(string dir, string pattern, List<string> files)
    {
        // Simpler than your previous loop...
        files.AddRange(Directory.GetFiles(dir, pattern));
        foreach (var subdirectory in Directory.GetDirectories(dir))
        {
            DirSearchImpl(subdirectory, pattern, files);
        }
    }
