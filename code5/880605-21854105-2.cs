    public static string GetEnumJson<T>()
    {
        Type type = typeof(T);
        if (!type.IsEnum)
            throw new NotSupportedException();
        var members = Enum.GetValues(type)
                          .Cast<T>()
                          .ToDictionary(e => e.ToString());
        return JsonConvert.SerializeObject(members);
    }
