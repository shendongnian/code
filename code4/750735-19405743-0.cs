    public string GetTypeName<T>()
    { 
        return Cache<T>.TypeName;
    }
    private static class Cache<T>
    {
        public static readonly TypeName = GetTypeName(typeof(T));
    }
