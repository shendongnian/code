    public static string ToJson<TEnum>()
    {
        var enumType = typeof(TEnum);
        if (!enumType.IsEnum)
        {
            throw new ArgumentException("enumType");
        }
        var names = Enum.GetNames(enumType);
        var values = Enum.GetValues(enumType)
            .OfType<Enum>()
            .Select(Convert.ToInt64);
        return string.Format(
            "[{0}]",
            string.Join(
                ", ",
                names.Zip(values, (n, v) => string.Format("{0}:{1}", n, v))));
    }
