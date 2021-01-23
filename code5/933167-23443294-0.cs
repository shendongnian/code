    public static bool EnumTryParse<T>(string s, out T value)
    {
        value = default(T);
        if (Enum.IsDefined(typeof(T), s))
        {
            value = (T)Enum.Parse(typeof(T), s);
            return true;
        }
        return false;
    }
