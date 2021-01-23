    public static class CollectionExtensions
    {
        public static bool IsNullOrEmptyCollection<T>(this T[] collection)
        {
            if (collection == null)
                return true;
            return collection.Length == 0;
        }
    }
