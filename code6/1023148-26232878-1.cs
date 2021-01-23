    public static class Extensions
    {
        public static string ParseValue(this ITwo ob)
        {
            return "Two";
        }
        public static string ParseValue<T>(this T obj) where T : class, IOne
        {
            return "One";
        }
    }
