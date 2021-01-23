    public IEnumerable<string> PastEntries
    {
        get
        {
            return FieldDefString.PastEntries
                   .Where(x => x.StartsWith(fieldValue, StringComparison.OrdinalIgnoreCase));
        }
    }
