    Filter(models, (MyModel m) => m.FirstName, "Joe", "contains"); 
    Filter(models, (MyModel m) => m.LastName, "Smith", "contains"); 
    private static IQueryable<MyModel> Filter(IQueryable<MyModel> query, Func<MyModel, string> property, string searchText, string searchFilter)
    {
        switch (searchFilter.ToLower())
        {
            case "contains":
                query = query.Where(x => property(x).ToLower().Contains(searchText.ToLower()));
                break;
            case "does not contain":
                query = query.Where(x => !property(x).ToLower().Contains(searchText.ToLower()));
                break;
            case "starts with":
                query = query.Where(x => property(x).StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase));
                break;
            case "ends with":
                query = query.Where(x => property(x).EndsWith(searchText, StringComparison.InvariantCultureIgnoreCase));
                break;
            case "equals":
                query = query.Where(x => property(x).Equals(searchText, StringComparison.InvariantCultureIgnoreCase));
                break;
        }
    
        return query;
    }
