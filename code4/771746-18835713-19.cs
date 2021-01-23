    public static IQueryable<MyTable> WhereFunctionContains(this IQueryable<MyTable> query)
    {
        var ints = new List<int>() { 1, 2, 3, 4, 5 };
        return query.Join(ints, mt=>mt.objid, i=>i, (t,i) => t);
    }
