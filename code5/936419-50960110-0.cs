    public static void Map<T1, T2>(this T1 obj1, T2 obj2) where T1 : class where T2 : class
    {
        IEnumerable<(PropertyInfo p1, PropertyInfo p2)> properties = typeof(T1).GetProperties()
            .Join(typeof(T2).GetProperties(), o => o.Name, t => t.Name, (o, t) => (o, t));
        foreach((PropertyInfo p1, PropertyInfo p2) in properties)
        {
            if (p1.CanWrite && p1.PropertyType == p2.PropertyType)
            {
                p1.SetValue(obj1, p2.GetValue(obj2));
            }
        }
    }
