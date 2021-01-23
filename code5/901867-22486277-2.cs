    private static IEnumerable<string> MyGetDirectories(string basePath)
    {
        try
        {
            string[] dirs = Directory.GetDirectories(basePath);
            return dirs.Union(dirs.SelectMany(dir => MyGetDirectories(dir)));
        }
        catch(UnauthorizedAccessException)
        {
            return Enumerable.Empty<string>();
        }
    }
