    private static IQueryable<MyModel> FilterFirstName(
        IQueryable<MyModel> query,
        Expression<Func<MyModel, string>> selector,
        string searchText,
        string searchFilter)
    {
        switch (searchFilter.ToLower())
        {
            case "contains":
                query = query.Where(selector.Compose(
                    text => text.ToLower().Contains(searchText.ToLower())));
                break;
            case "does not contain":
                query = query.Where(selector.Compose(
                    text => !text.ToLower().Contains(searchText.ToLower())));
                break;
            case "starts with":
                query = query.Where(selector.Compose(
                    text => text.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase)));
                break;
            case "ends with":
                query = query.Where(selector.Compose(
                    text => text.EndsWith(searchText, StringComparison.InvariantCultureIgnoreCase)));
                break;
            case "equals":
                query = query.Where(selector.Compose(
                    text => text.Equals(searchText, StringComparison.InvariantCultureIgnoreCase)));
                break;
        }
        return query;
    }
