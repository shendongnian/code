    public bool IsHashSet(object obj)
    {
        var t = obj.GetType();
        if (t.IsGenericType) {
             return t.GetGenericTypeDefinition() == typeof(HashSet<>);
        }
        return false;
    }
