    public static IEnumerable<string> GetFilesLinq(
        string root,
        Func<string, bool> directoryFilter,
        string filePattern)
    {
        var directories = Directory.GetDirectories(root, "*.*", SearchOption.AllDirectories)
            .Where(directoryFilter);
        List<string> results = new List<string>();
        foreach (var d in directories)
        {
            results.AddRange(Directory.GetFiles(d, filePattern, SearchOption.TopDirectoryOnly));
        }
        return results;
    }
