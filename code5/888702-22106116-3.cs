    void Search(IQueryable<Entity> results, string keywords,
        Expression<Func<Entity, string>> selector)
    {
        results = results.Where(selector.Compose(obj => obj.Contains(keywords)));
    }
