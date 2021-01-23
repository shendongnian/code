    public static Type MostDerivedCommonType(IEnumerable<object> objects)
    {
        return objects.Select(o => BaseClassHierarchy(o))
            .Aggregate((a,b)=> a.Intersect(b))
            .First();
    }
