    public static class DefaultExtension
    {
        public static IEnumerable<PropertyInfo> GetProperties<T>(this Type type)
        {
            return type.GetProperties().Where(p => p.PropertyType == typeof (T));
        }
        public static void SetDefaults<T>(this T toDefault)
        {
            foreach (PropertyInfo p in toDefault.GetType().GetProperties())
            {
                foreach (var dv in p.GetCustomAttributes(true).OfType<DefaultValueAttribute>())
                {
                    p.SetValue(toDefault, dv.Value, null);
                }
            }
        }
    } 
