    static class Extensions
    {
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
        
        public static bool IsNull<T>(this T? obj) where T : struct
        {
            return !obj.HasValue;
        }
    }
