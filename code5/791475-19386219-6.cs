    public static IEnumerable<string> GetFiles(
        string path, string searchPatternExpression = "",
        SearchOption searchOption = SearchOption.AllDirectories,
        params string[] toIgnore)
    {
        var hash = new HashSet<string>(toIgnore, StringComparer.InvariantCultureIgnoreCase);
        Regex reSearchPattern = new Regex(searchPatternExpression);
        return Directory.EnumerateDirectories(path, "*", searchOption)
                        .Where(folder => !hash.Contains(Path.GetDirectoryName(folder)))
                        .SelectMany(x => Directory.EnumerateFiles(x, "*", searchOption));
    }
