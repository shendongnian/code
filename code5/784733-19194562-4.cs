    private static readonly Dictionary<Type, Node<Type>> _visitedTypes = new Dictionary<Type, Node<Type>>();
    public static Node<Type> CreateTypeNode(Type type)
    {
        Node<Type> node;
        if (_visitedTypes.TryGetValue(type, out node))
        {
            return node;
        }
        // add the key to the cache to prevent infinite recursion; the value will be set later
        // if this type will be found again in a recursive call CreateTypeNode returns null
        // (null will be filtered out then)
        _visitedTypes.Add(type, null);
        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        var types = new HashSet<Type>(properties.Select(prop => GetElementType(prop.PropertyType)));
        var children = types.Select(CreateTypeNode).Where(n => n != null);
        node = new Node<Type>(type, children);
        _visitedTypes[type] = node;
        return node;
    }
