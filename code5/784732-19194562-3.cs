    public static Node<Type> CreateTypeNode(Type type)
    {
        var children = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                           .Select(prop => GetElementType(prop.PropertyType))
                           .Select(CreateTypeNode);
        return new Node<Type>(type, children);
    }
