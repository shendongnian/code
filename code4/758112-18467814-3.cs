    public static class ObjectExtensions
    {
        public static IEnumerable<String> GetFields<T>(this T obj)
            where T : class
        {
            return GetFieldsFor<T>();
        }
        public static IEnumerable<String> GetFieldsFor<T>()
        {
            return typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name);
        }
        
        public static IEnumerable<String> GetProperties<T>(this T obj)
            where T : class
        {
            return GetPropertiesFor<T>();
        }
        public static IEnumerable<String> GetPropertiesFor<T>()
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name);
        }
    }
