    // rewrites the specified file, removing all lines matched by the predicate
    public static void RemoveLinesFromFile(string filename, Func<string, bool> match)
    {
        var linesToKeep = File.ReadAllLines(filename)
            .Where(line => match(line))
            .ToList();
        File.WriteAllLines(filename, linesToKeep);
    }
    // gets the list of "delete codes" from the specified ini file
    public IList<string> GetDeleteCodeList(string iniPath)
    {
        return File.ReadLines(iniPath)
            .SkipWhile(l => l.Trim() != "[DELETE]")
            .Skip(1).ToList();
    }
    // removes lines from a tab-delimited file, where the specified listOfCodes contains
    // at least one of the tokens inside that line
    public static void RemoveLinesUsingCodeList(
        string filename,
        IList<string> listOfCodes,
        bool shouldTrimQuotes)
    {
        RemoveLinesFromFile(filename, line =>
        {
            IEnumerable<string> tokens = line.Split('\t');               
            if (shouldTrimQuotes)
            {
                tokens = tokens.Select(v => v.Trim(' ', '"'));
            }
            return (tokens.Any(t => listOfCodes.Any(t.Equals)));
        });
    }
