    public static class CollectionExtensions
    {
        public static bool IsEmptyCollection<T>(this T[] collection)
        {
            if (collection == null)
                return true;
            return collection.Length == 0;
        }
    }
