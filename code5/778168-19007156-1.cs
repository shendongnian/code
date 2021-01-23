    public IEnumerable<string> GetFiles(string searchPatternExpression)
    {
        string path = @"D:\xxx\";
        SearchOption searchOption = SearchOption.TopDirectoryOnly;
        Regex reSearchPattern = new Regex(searchPatternExpression);
        return Directory
            .EnumerateFiles(path, "*", searchOption)
            .Where(file => reSearchPattern.IsMatch(Path.GetFileName(file)))
            .OrderBy(file => new FileInfo(file).CreationTime);
    }
