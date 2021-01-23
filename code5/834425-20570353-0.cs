    public static IEnumerable<T> Filter<T>(IEnumerable<T> source, string searchStr)
    {
        var propsToCheck = typeof (T).GetProperties().Where(a => a.PropertyType == typeof(string));
    
        var filter = propsToCheck.Aggregate(string.Empty, (s, p) => (s == string.Empty ? string.Empty : string.Format("{0} OR ", s)) + string.Format("{0} == @0", p.Name));
    
        var filtered = source.AsQueryable().Where(filter, searchStr);
        return filtered;
    }
