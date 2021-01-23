    /// <exception cref="AmbiguousMatchException">More attributes found. </exception>
    /// <exception cref="TypeLoadException">Cannot load custom attribute.</exception>
    public static string GetDescription(this Enum value)
    {
        Type type = value.GetType();
        string enumName = Enum.GetName(type, value);
        if (enumName == null)
        {
            return null; // or string.Empty
        }
        FieldInfo typeField = type.GetField(enumName);
        if (typeField == null)
        {
            return null; // or string.Empty
        }
        var attribute = Attribute.GetCustomAttribute(typeField, typeof(DescriptionAttribute));
        return (attribute as DescriptionAttribute)?.Description; // ?? string.Empty maybe added
    }
