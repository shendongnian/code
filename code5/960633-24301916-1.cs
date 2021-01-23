    public IEnumerable<object> Properties()
    {
        return typeof(Person).GetProperties()
                             .OrderBy(p => p.Name)
                             .Select(p => p.GetValue(this, null));
    }
