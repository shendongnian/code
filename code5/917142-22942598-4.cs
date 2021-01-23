    public static object ConvertList(List<object> value, Type type)
    {
        var containedType = type.GenericTypeArguments.First();
        return value.Select(item => Convert.ChangeType(item, containedType)).ToList();
    }
