    public static class EnumHelper 
    {
        public static string GetName<T>(this T value) where T : struct
        {
            string name;
            return Cache<T>.names.TryGetValue(value, out name) ? name : null;
        }
        private static class Cache<T>
        {
            public static readonly Dictionary<T, string> names = (
                       from field in typeof(T).GetFields(
                           System.Reflection.BindingFlags.Static | 
                           System.Reflection.BindingFlags.Public)
                       where field.IsLiteral
                       let value = (T)field.GetValue(null)
                       let xa = (System.Xml.Serialization.XmlEnumAttribute)
                           Attribute.GetCustomAttribute(field,
                           typeof(System.Xml.Serialization.XmlEnumAttribute))
                       select new
                       {
                           value,
                           name = xa == null ? value.ToString() : xa.Name
                       }
                    ).ToDictionary(x => x.value, x => x.name);
        }
    
    }
