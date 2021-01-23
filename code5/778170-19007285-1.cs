    public IEnumerable<string> GetFiles(string searchPatternExpression)
    {
        string path = @"D:\xxx\";
        SearchOption searchOption = SearchOption.TopDirectoryOnly;
        Regex reSearchPattern = new Regex(searchPatternExpression);
        return new DirectoryInfo(path)
            .EnumerateFiles("*", searchOption)
            .Where(file => reSearchPattern.IsMatch(file.Name))
            .OrderBy(file => file.CreationTime)
            .Select(file => file.FullName); // return just names
    }
