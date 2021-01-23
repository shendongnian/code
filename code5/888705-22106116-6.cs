    void Search(IQueryable<Entity> results, IEnumerable<string> keywords,
        Expression<Func<Entity, string>> selector)
    {
        var finalFilter = keywords.Aggregate(
            PredicateBuilder.False<Entity>(),
            (filter, keyword) => filter.Or(
                selector.Compose(obj => obj.Contains(keyword))));
        results = results.Where(finalFilter);
    }
