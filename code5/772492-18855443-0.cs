    public static Dictionary<int, string> GetEnumList<T>()
    {
        Type enumType = typeof(T);
        if (!enumType.IsEnum)
            throw new Exception("Type parameter should be of enum type");
        return Enum.GetValues(enumType).Cast<int>()
                   .ToDictionary(v => v, v => Enum.GetName(enumType, v));
    }
