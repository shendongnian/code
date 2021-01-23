    Dictionary<string, List<int>> GetSymbolMatches(string input, params string[] symbols)
    {
        Dictionary<string, List<int>> results = new Dictionary<string, List<int>>();
    
        foreach(string symbol in symbols)
        {
            results.Add(symbol, GetAllIndices(input, symbol));
        }
    
        return results;
    }
