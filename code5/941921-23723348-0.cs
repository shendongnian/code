    public void UpdateNamesList(string _searchTerm)
    {
        IEnumerable<string> names = MethodCallToGetStrings()
            .Where(x => x.Name.Contains(_searchTerm))
            .Select(x => x.Name);
    
        NamesList.Clear();
        foreach(name in names) 
        {
           NamesList.Add(name);
        }
    }
