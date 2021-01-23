    public bool IsHashSet(object obj)
    {
        if (obj != null) 
        {
            var t = obj.GetType();
            if (t.IsGenericType) {
                return t.GetGenericTypeDefinition() == typeof(HashSet<>);
            }
        }
        return false;
    }
