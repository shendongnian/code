    public string GetEnumDescription<T>(T enumValue) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T has to be an enum");
        FieldInfo field = typeof(T).GetField(enumValue.ToString());
        if (field != null)
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute != null)
                return attribute.Description;
        }
        return null; // not found or no description
    }
