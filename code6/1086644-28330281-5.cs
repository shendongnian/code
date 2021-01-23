    public static class Properties<TSource>
    {
        public static List<string> GetNames<TResult>(Func<TSource, TResult> ignored)
        {
            // Use normal reflection to get the properties
        }
    }
