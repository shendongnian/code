    public static class ObjectExtensions
    {
        /*
         * Field Methods
         */
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
        public static IDictionary<String, Object> GetFieldValueDictionary<T>(this T obj)
            where T : class
        {
            IDictionary<String, Object> result = new Dictionary<String, Object>();
            IEnumerable<FieldInfo> properties = typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }        
        /*
         * Property methods
         */
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
        public static IDictionary<String, Object> GetPropertyValueDictionary<T>(this T obj)
            where T : class
        {
            IDictionary<String, Object> result = new Dictionary<String, Object>();
            IEnumerable<PropertyInfo> properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }
    }
