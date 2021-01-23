    public static IEnumerable<Type> MyGetTypes(Group group)
    {
        if(group == null)
            return Enumerable.Empty<Type>();
        else
            return group.GetTypes();
    }
