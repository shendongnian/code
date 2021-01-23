    public void DoSearch(string searchTerm)
    {
       MyBindableProperty = new SearchResult
        {
            SearchTerm = searchTerm,
            Results = dict.Where(item =>  iteem.Value.ToUpperInvariant().Contains(searchTerm.ToUpperInvariant())).ToDictionary(v => v.Key, v => v.Value)
        };
        
    }
