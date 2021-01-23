    public static T To<T>(this object source) where T : IConvertible
    {
        return (T)Convert.ChangeType(source, typeof(T));
    }
    public static bool IsNumeric(this Type t)
    {
        return t.In(typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), 
                    typeof(int), typeof(uint), typeof(long), typeof(ulong), 
                    typeof(float), typeof(double), typeof(decimal));
    }
    public static bool In<T>(this T source, params T[] list)
    {
        return list.Contains(source);
    }
