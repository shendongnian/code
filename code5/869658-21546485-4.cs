    public static PropertyInfo[] GetPropertiesByType(this Type t)
        {
            if (!t.IsPrimitive
                || t != typeof (System.Decimal)
                || t != typeof (System.String)
                || t != typeof(System.DateTime)
                || t != typeof (System.DateTime?))
            {
    
                return t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .OrderBy(p => p.Name).ToArray();
            }
            else
            return new PropertyInfo[0];
        }
