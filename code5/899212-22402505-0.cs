    public static class Extension
    {
        public static MyCollection ToMyCollection(this IEnumerable<MyType> enumerable)
        {
            return new MyCollection(enumerable);
        }
    }
