    public static List<Type> SafeUnion(this Group group1, Group group2)
    {
        return (group2 != null ?
                group1.GetTypes().Union(group2.GetTypes()) : group1.GetTypes();
    }
