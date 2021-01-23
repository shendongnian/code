    public static IEnumerable<T> ToValues<T>(this T flags) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enumerated type.");
        int inputInt = (int)(object)(T)flags;
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            int valueInt = (int)(object)(T)value;
            if (0 != (valueInt & inputInt))
            {
                yield return value;
            }
        }
    }
