    private IEnumerable<string> GetMatchingLines(string filename, string word)
    {
        return File.ReadLines(filename)
                   .Where(line => string.Equals(line.Split(' ').FirstOrDefault(), 
                                                word,
                                                StringComparison.InvariantCultureIgnoreCase));
    }
