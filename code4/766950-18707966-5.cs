    public Type MostDerivedCommonBase(IEnumerable<Type> types)
    {
        if (!types.Any()) return null;
    
        var counts = new Dictionary<Type, int>();
        var total = types.Count();
        foreach(var type in types.SelectMany(t => t.TypeHierarchy()))
        {
            if (!counts.ContainsKey(type))
            {
                counts[type] = 1;
            }
            else
            {
                counts[type]++;
            }
        }
    
        return types.First().TypeHierarchy().First(t => counts[t] == total);
    }
