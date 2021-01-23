    public IEnumerable<ListItem> GetItems(this ClientContext context,
        string listName,
        params Expression<Func<ListItem, object>>[] retrievals)
    {
        var query = new CamlQuery();
        var queryResults = context.Web.Lists.GetByTitle(listName)
            .GetItems(query)
            .Include(retrievals);
        context.LoadQuery(queryResults);
        context.ExecuteQuery();
        return queryResults;
    }
