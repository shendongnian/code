    public static string GetEnumJson<T>()
        where T : struct
    {
        Type type = typeof(T);
        if (!type.IsEnum)
            throw new NotSupportedException();
        var members = Enum.GetValues(type)
                          .Cast<T>()
                          .ToDictionary(e => e.ToString());
        return JsonConvert.SerializeObject(members);
    }
