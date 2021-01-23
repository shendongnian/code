    static int? FastCountOrZero(this IEnumerable items)
    {
        if (items == null)
            return 0;
        var collection = items as ICollection;
        if (collection != null)
            return collection.Count;
        var roCollection = items as IReadOnlyCollection<object>; // only for reference types
        if (roCollection != null)
            return roCollection.Count;
        var source = items as IQueryable;
        if (source != null)
            return QueryableEx.Count(source);
       
        return items.Cast<object>().Count();
    }
