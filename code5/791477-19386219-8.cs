    public static IEnumerable<string> GetFiles(
        string path, string searchPatternExpression = "",
        SearchOption searchOption = SearchOption.AllDirectories,
        params string[] toIgnore)
    {
        var hash = new HashSet<string>(toIgnore, StringComparer.InvariantCultureIgnoreCase);
        Regex reSearchPattern = new Regex(searchPatternExpression);
        return Directory.EnumerateFiles(path, "*", searchOption)
                        .Where(file => reSearchPattern.IsMatch(System.IO.Path.GetExtension(file)))
                        .Where(file => !hash.Contains(file));
    }
