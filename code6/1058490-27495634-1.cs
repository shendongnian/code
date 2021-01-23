    static void Main(string[] args)
    {
        var path = args[0];
        var theEntries =
            from fileContent in ReadFile(path)
            from entries in ParseEntries(fileContent)
            select entries;
        var theContents = 
            from entry in theEntries.UnfoldAll() 
            where entry.HasValue 
            select Download(entry.Value.Value);
        foreach (var content in theContents)
        {
            //...
        }
    }
