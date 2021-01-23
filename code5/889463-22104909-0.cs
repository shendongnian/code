    public IEnumerable<MyObject> Filter(string filter)
    {
        return objects.Where(o => o.Name.Contains(filter) ||
                                string.IsNullOrWhiteSpace(filter) == false);
    }
