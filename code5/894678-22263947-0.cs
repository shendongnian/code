    IDictionary<string, List<File>> BuildIndex(IEnumerable<File> files)
    {
        var index = new Dictionary<string, List<File>>();
        foreach (File file in files)
        {
            foreach (string keyword in file.Keywords.Select(k => k.Name))
            {
                if (!index.ContainsKey(keyword))
                    index[keyword] = new List<File>();
                index[keyword].Add(file);
            }
        }
        return index;
    }
    IEnumerable<File> FindByKeywords(IEnumerable<Keyword> keywords)
    {
        var index = BuildIndex(Context.Files);
        return keywords
            .Where(k => index.ContainsKey(k.Name))
            .SelectMany(k => index[k.Name])
            .Distinct()
            .ToList();
    }
