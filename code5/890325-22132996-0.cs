    public static T ToMask<T>(this IEnumerable<T> values) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enumerated type.");
         int builtValue = 0;
         foreach (T value in Enum.GetValues(typeof(T)))
         {
            if (values.Contains(value))
            {
                builtValue |= Convert.ToInt32(value);
            }
        }
        return (T)Enum.Parse(typeof(T), builtValue.ToString());
    }
