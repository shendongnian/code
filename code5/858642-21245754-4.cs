    public static IEnumerable<ListItem> GetItems(this ClientContext context,
        string listName,
        params Expression<Func<ListItem, object>>[] retrievals)
    {
        var query = new CamlQuery();
        var queryResults = context.Web.Lists.GetByTitle(listName)
            .GetItems(query);
        Expression<Func<ListItemCollection, ItemSelector, object>> includeSelector =
            (items, selector) => items.Include(selector);
        context.Load(queryResults, retrievals
            .Select(selector => includeSelector.Apply(selector))
            .ToArray());
        context.ExecuteQuery();
        return queryResults;
    }
