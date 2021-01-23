    static class ReflectionIndexedProperty
    {
        public static void SetValueByCoordinates(this IBindingList list, int x, int y, object value)
        {
            object o = list[x];
            GetProperty(o, y).SetValue(o, value);
        }
        public static object GetValueByCoordinates(this IBindingList list, int x, int y)
        {
            object o = list[x];
            return GetProperty(o, y).GetValue(o);
        }
        private static PropertyInfo GetProperty(object o, int index)
        {
            Type type = o.GetType();
            PropertyInfo[] properties;
            if (!_typeToProperty.TryGetValue(type, out properties))
            {
                properties = type.GetProperties();
                Array.Sort(properties, (p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase));
                _typeToProperty[type] = properties;
            }
            return properties[index];
        }
        private static readonly Dictionary<Type, PropertyInfo[]> _typeToProperty = new Dictionary<Type, PropertyInfo[]>();
    }
