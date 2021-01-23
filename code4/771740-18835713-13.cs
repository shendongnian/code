    public static IQueryable<T> WhereFunctionContains<T>(this IQueryable<T> query) where T : IHasObjID
    {
        var intsToFind = FillObjectsToFind();
        return query.Where(t => intsToFind.Contains(t.ObjID));
    }
