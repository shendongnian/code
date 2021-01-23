    public static class FieldAndPropertyExtensions
    {
        /*
         * Field Methods
         */
        
        public static IEnumerable<String> GetFields<T>(this T obj, Boolean includeInheritedFields = true) where T : class
        {
            return getFieldsFor<T>(includeInheritedFields).Select(x => x.Name);
        }
        public static IEnumerable<String> GetFieldsFor<T>(Boolean includeInheritedFields = true) where T : class
        {
            return getFieldsFor<T>(includeInheritedFields).Select(x => x.Name);
        }
        public static IDictionary<String, Object> GetFieldValueDictionary<T>(this T obj, Boolean includeInheritedFields = true) where T : class
        {
            IEnumerable<FieldInfo> fields = getFieldsFor<T>(includeInheritedFields);
            
            IDictionary<String, Object> result = new Dictionary<String, Object>();
            foreach (var field in fields)
            {
                result.Add(field.Name, field.GetValue(obj));
            }
            return result;
        }
        
        /*
         * Property Methods
         */
        
        public static IEnumerable<String> GetProperties<T>(this T obj, Boolean includeInheritedProperties = true) where T : class
        {
            return getPropertiesFor<T>(includeInheritedProperties).Select(x => x.Name);
        }
        public static IEnumerable<String> GetPropertiesFor<T>(Boolean includeInheritedProperties = true) where T : class
        {
            return getPropertiesFor<T>(includeInheritedProperties).Select(x => x.Name);
        }
        public static IDictionary<String, Object> GetPropertyValueDictionary<T>(this T obj, Boolean includeInheritedProperties = true) where T : class
        {
            IEnumerable<PropertyInfo> properties = getPropertiesFor<T>(includeInheritedProperties);
        
            IDictionary<String, Object> result = new Dictionary<String, Object>();
            foreach (var property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }
        
        /*
         * Helper methods
         */
        private static IEnumerable<FieldInfo> getFieldsFor<T>(Boolean includeInheritedFields = true) where T : class
        {
            return typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => includeInheritedFields || x.DeclaringType == typeof(T));
        }
        private static IEnumerable<PropertyInfo> getPropertiesFor<T>(Boolean includeInheritedFields = true) where T : class
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => includeInheritedFields || x.DeclaringType == typeof(T));
        }
    }
