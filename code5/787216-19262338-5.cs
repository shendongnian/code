    public virtual IEnumerable<Matter> GetMattersForAutoCompleteByCode(string input)
    {
        InvalidateCache();
        IEnumerable<Matter> results;
        //Searching Matter Object on all 4 given parameters by input.
    
        if (_lastMatters != null && input.StartsWith(_lastSearch) && _lastMatters.Any())
        {
            results = _lastMatters.Where(m => m.IsInputLike(input)).OrderBy(m => m.Code);
            _lastMatters = results;
        }
        else
        {
            results = _matters.Where(m => m.IsInputLike(input)).OrderBy(m => m.Code);
            _lastMatters = results;
        }
    
        _lastSearch = input;
    
        return results.Take(10).ToList();
    }
