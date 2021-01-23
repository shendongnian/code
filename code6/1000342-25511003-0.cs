    public static IQueryable<T> Match<T>(
        string searchTerm, 
        IQueryable<T> data, 
        params Expression<Func<T, string>>[] filterProperties) where T : class
    {
        var predicates = new List<string>();
        foreach (var prop in filterProperties)
        {
            var lambda = prop.ToString();
            var columnName = lambda.Substring(lambda.IndexOf('.') + 1);
            var predicate = string.Format(
                "({0} != null && {0}.ToUpper().Contains(@0))", columnName);
            predicates.Add(predicate);
        }
        var filter = string.Join("||", predicates);
        var results = data.Where(filter, searchTerm);
        return results;
    }
