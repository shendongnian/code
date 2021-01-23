    private static IEnumerable<string> GetDirectories(string basePath)
    {
        try
        {
            string[] dirs = Directory.GetDirectories(basePath);
            return dirs.Union(dirs.SelectMany(dir => GetDirectories(dir)));
        }
        catch(UnauthorizedAccessException)
        {
            return Enumerable.Empty<string>();
        }
    }
