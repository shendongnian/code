    public static class ObjectExtension
    {
        static IDictionary<KeyValuePair<Type, string>, PropertyInfo> propertyCache = new Dictionary<KeyValuePair<Type, string>, PropertyInfo>();
        public static object GetProperty(this object source, string propertyName, bool useCache = true)
        {
            if (source == null)
            {
                return null;
            }
            var sourceType = source.GetType();
            KeyValuePair<Type, string> kvp = new KeyValuePair<Type, string>(sourceType, propertyName);
            PropertyInfo property = null;
            if (!useCache || !propertyCache.ContainsKey(kvp))
            {
                property = sourceType.GetProperty(propertyName);
                if (property == null)
                {
                    return null;
                }
                var get = property.GetGetMethod();
                if (get == null)
                {
                    return null;
                }
                if (useCache)
                {
                    propertyCache.Add(kvp, property);
                }
            }
            else
            {
                property = propertyCache[kvp];
            }
            return property.GetValue(source, null);
        }
        public static T GetProperty<T>(this object source, string propertyName)
        {
            object value = GetProperty((object)source, propertyName);
            if (value == null)
            {
                return default(T);
            }
            return (T)value;
        }
    }
