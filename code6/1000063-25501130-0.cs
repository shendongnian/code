    public static class Extensions
    {
        public static bool IsEmpty(this IEnumerable collection)
        {
            return !collection.Cast<object>().Any();
        }
    }
