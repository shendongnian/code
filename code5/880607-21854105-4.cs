    public static string GetEnumJson<T>()
        where T : struct
    {
        Type type = typeof(T);
        if (!type.IsEnum)
            throw new NotSupportedException();
        var members = Enum.GetNames(type)
                          .ToDictionary(s => s, s => Enum.Parse(type, s));
        return JsonConvert.SerializeObject(members);
    }
