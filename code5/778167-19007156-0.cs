    public IEnumerable<string> GetFiles(string searchPatternExpression)
    {
        string path = @"D:\xxx\";
        SearchOption searchOption = SearchOption.TopDirectoryOnly;
        Regex reSearchPattern = new Regex(searchPatternExpression);
        return Directory
            .EnumerateFiles(path, "*", searchOption)
            .Where(file => reSearchPattern.IsMatch(Path.GetFileName(file)))
            .Select(file => new FileInfo(file))
            .OrderBy(fileInfo => fileInfo.CreationTime);
    }
