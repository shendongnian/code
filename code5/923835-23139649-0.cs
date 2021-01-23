    public static void Convert<T>(string text, out T value, CultureInfo culture) where T : IConvertible
    {
        if (typeof(T).IsEnum)
        {
            value = (T) Enum.Parse(typeof (T), text, true);
        }
        else
        {
            value = (T)System.Convert.ChangeType(text, typeof(T), culture);
        }
    }
