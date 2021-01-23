    public static string GetEnumDescription<T>(T enumValue) where T : struct, Enum
    {
        FieldInfo field = typeof(T).GetField(enumValue.ToString());
        if (field != null)
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute != null)
                return attribute.Description;
        }
        return null; // not found or no description
    }
