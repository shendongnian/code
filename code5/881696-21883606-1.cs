    var y2 = values.GetAttributes<DescriptionAttribute, DataFiat>();
    public static T[] GetAttributes<T, T2>(this IEnumerable<T2> values) where T : Attribute
    {
        List<T> ts =new List<T>();
        foreach (T2 value in values)
        {
            T attribute;
            MemberInfo info = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            if (info != null)
            {
                attribute = (T)info.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                ts.Add(attribute);
            }
        }
        return ts.ToArray();
    }
