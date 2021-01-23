    public static IEnumerable<T> FlattenProperty<T>(
        this IEnumerable<Group> groups, 
        Func<Group,T> transform)
    {
        foreach(Group g in groups)
        {
            yield return transform(g);
            foreach(var item in g.SubGroups.FlattenProperty(transform))
                yield return item;
        }
    }
