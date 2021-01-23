    public static T Parse<T>(object value)
    {
        var isNullable = typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>);
        var itemType = isNullable ? typeof(T).GetGenericArguments()[0] : typeof(T);
        if (!itemType.IsEnum)
            throw new ArgumentException("T must be an Enum type or Nullable<> of Enum type.");
        if (value == null || value == DBNull.Value)
        {
            if (isNullable)
                return default(T);  // default(Nullable<>) is null
            throw new ArgumentException("Cannot parse enum, value is null.");
        }
        if (value is String)
        {
            return (T)Convert.ChangeType(Enum.Parse(itemType, value.ToString()), itemType);
        }
        return (T)Convert.ChangeType(Enum.ToObject(itemType, value), itemType);
    }
