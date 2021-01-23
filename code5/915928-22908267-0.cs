    private Lazy<IEnumerable<Func<T, string>>> properties = new Lazy<IEnumerable<Func<T, string>>>(GetPropertyFunctions<T>);
    
    public bool Match<T>(T item, string searchTerm)
    {
        bool match = properties.Value.Select(prop => prop(item)).Any(value => value != null && value.ToLower().Contains(searchTerm.ToLower()));
        return match;
    }
