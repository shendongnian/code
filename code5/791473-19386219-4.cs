    public static IEnumerable<string> GetFiles(
        string path, string searchPatternExpression = "",
        SearchOption searchOption = SearchOption.AllDirectories,
        params string[] toIgnore)
    {
        Regex reSearchPattern = new Regex(searchPatternExpression);
        return Directory.EnumerateFiles(path, "*", searchOption)
                        .Where(file => reSearchPattern.IsMatch(System.IO.Path.GetExtension(file)))
                        .Where(file => !toIgnore.Contains(file));
    }
