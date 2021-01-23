    public Type MostDerivedCommonBase(IEnumerable<Type> types)
    {
        if (!types.Any()) return null;
        var counts = types.SelectMany(t => t.TypeHierarchy())
                          .GroupBy(t => t)
                          .ToDictionary(g => g.Key, g => g.Count());
        var total = counts[typeof(object)]; // optimization instead of types.Count()
        return types.First().TypeHierarchy().First(t => counts[t] == total);
    }
