    public static PropertyInfo[] GetPropertiesByType(this Type t)
        {
            if (t.IsPrimitive || t == typeof(Decimal) || t == typeof(String) || ... )
        {
            return //empty array
        }
            return t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .OrderBy(p => p.Name).ToArray();
        }
