    public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> entities, string propertyName)
    {
        if (!entities.Any() || string.IsNullOrEmpty(propertyName))
            return entities;
     
        var propertyInfo = entities.First().GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        return entities.OrderBy(e => propertyInfo.GetValue(e, null));
    }
