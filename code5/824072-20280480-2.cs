    public IEnumerable<string> GetElements()
    {
        yield return specName;
        yield return delimiters;
        . . . // you get the idea.
        foreach (Column column in Columns)
        {
            yield return column.Name;
        }
        yield return testrangefile.Filename;
    }
