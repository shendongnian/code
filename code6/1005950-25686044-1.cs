    var query = foo.Where(a => SearchResult.Name == null ||
                               a.Name == SearchResult.Name);
    if (condition != null)
    {
        query = condition.Value ? query.Where(a => a.PersonType != null)
                                : query.Where(a => a.PersonType == null);
    }
