    public static class DefaultExtension
    {
        public static IEnumerable<PropertyInfo> GetProperties<T>(this Type type)
        {
            return type.GetProperties().Where(p => p.PropertyType == typeof (T));
        }
       public static void SetListDefaults<T>(this T toDefault)
        {
            foreach (PropertyInfo p in toDefault.GetType().GetProperties<List<Class1>>())
            {
                foreach (var dv in p.GetCustomAttributes(true).OfType<DefaultValueAttribute>())
                {
                    var pValue = p.GetValue(toDefault, null) as List<Class1>;
                    if (pValue != null)
                    {
                        foreach (var class1 in pValue)
                        {
                            class1.Naming = ((Class1) dv.Value).Naming;
                        }
                    }
                }
            }
        }
    }
