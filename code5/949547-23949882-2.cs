    public static class Extension
    {
        public static bool HasValue<T>(this T self) where T : class
        {
            return self != null;
        }
    }
