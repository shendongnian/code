    public IQueryable<Lifetime> GetLifetimes<T>(IQueryable<T> entities)
    {
        var machines = entities as IQueryable<Machine>;
        if (machines != null)
            return machines.SelectMany (m => m.Items)
                           .SelectMany (i => i.Tools)
                           .SelectMany (i => i.Parts)
                           .SelectMany (i => i.Lifetimes);
        
        var items = entities as IQueryable<Item>;
        if (items != null)
            return items.SelectMany (i => i.Tools)
                        .SelectMany (i => i.Parts)
                        .SelectMany (i => i.Lifetimes);
        
        var tools = entities as IQueryable<Tool>;
        if (tools != null)
            return tools.SelectMany (i => i.Parts)
                        .SelectMany (i => i.Lifetimes);
        
        var parts = entities as IQueryable<Part>;
        if (parts != null)
            return parts.SelectMany (i => i.Lifetimes);
        
        return Enumerable.Empty<Lifetime>().AsQueryable();
    }
