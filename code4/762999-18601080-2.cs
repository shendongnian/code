    static IEnumerable<IEnumerable<PropertyInfo>> FlattenProperties(
        Type type,
        IEnumerable<PropertyInfo> ancestors = null)
    {
        // change to Assumptions #1/#2 or #5 to yield break
        // ...
        ancestors = ancestors ?? Enumerable.Empty<PropertyInfo>();
        var properties = type.GetProperties(
                              BindingFlags.FlattenHierarchy
                            | BindingFlags.Instance
                            | BindingFlags.Public);
        foreach (var property in properties)
        {
            // again, Assumption #3: your class hierarchy won't destroy recursion
            // Assumption #6: you actually want the initial nested property too
            yield return ancestors.Concat(new[] { property });
            foreach (var nested in FlattenProperties(
                property.PropertyType, 
                ancestors.Concat(new [] { property })))
            {
                yield return nested;
            }
        }
    }
