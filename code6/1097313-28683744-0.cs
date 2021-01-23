    public static class TypeExtensions
    {
        public static T GetStaticPropertyValueOfType<T>(this Type type, string name)
        {
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null 
                && property.GetIndexParameters().Length == 0
                && typeof(T).IsAssignableFrom(property.PropertyType) 
                && property.GetGetMethod(true) != null)
            {
                return (T)property.GetGetMethod(true).Invoke(null, new object [0]);
            }
            var field = type.GetField(name, BindingFlags.Public | BindingFlags.Static);
            if (field != null
                && typeof(T).IsAssignableFrom(field.FieldType))
                return (T) field.GetValue(null);
            return default(T);
        }
    }
