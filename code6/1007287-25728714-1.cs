    public static IQueryable<FileColumnRecords> DynamicColumnQuery
                                    (this IQueryable<FileColumnRecords> query, 
                                    List<QueryColumn> querycolumns)
    {
        var predicate = PredicateBuilder.False<FileColumnRecords>();
        foreach (QueryColumn columnQuery in querycolumns)
        {
            string temp = columnQuery.queryTerm.ToLower();
            predicate = predicate.Or(d => d.fcv.Any(f => (f.value != null ?
                                     f.value.ToLower().Contains(temp) : false));
        }
        return query.AsExpandable().Where(predicate);
    }
