    public static string ToQuery(object root, IDictionary<Type, IQueryPartDescriptor> partDescriptors)
    {
        var queryBuilder = new StringBuilder();
        AddQueryPart(root, String.Empty, partDescriptors, queryBuilder);
        return queryBuilder.Insert(0, '?').ToString();
    }
    private static void AddQueryPart(
        object obj,
        string prefixInQuery,
        IDictionary<Type, IQueryPartDescriptor> partDescriptors,
        StringBuilder queryBuilder)
    {
        var queryPartDescriptor = partDescriptors[obj.GetType()];
        queryBuilder
            .Append(queryPartDescriptor.ObjectToQueryPart(prefixInQuery, obj));
        foreach (var childrenListDescriptor in queryPartDescriptor.ChildrenListsDescriptors)
        {
            var children = childrenListDescriptor.GetChildren(obj).ToList();
            for (var childIndex = 0; childIndex < children.Count; childIndex++)
            {
                var childPrefix = childrenListDescriptor.BuildChildPrefix(childIndex, prefixInQuery);
                AddQueryPart(children[childIndex], childPrefix, partDescriptors, queryBuilder);
            }
        }
    }
