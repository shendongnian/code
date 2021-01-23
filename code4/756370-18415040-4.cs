    public static string GetDescriptionOrDefault<T>(this T enumValue, string defaultValue = null)
    {
        var attr = typeof(T)
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;
        return attr == null ? (defaultValue ?? enumValue.ToString()) : attr.Description;
    }
