    public static class ReflectionExtensions
    {
        public static Type GetCompileTimeType<T>(this T obj)
        {
            return typeof(T);
        }
    }
