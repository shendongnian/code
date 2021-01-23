    public object ToEnum(Type enumType, object value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        if (!type.IsEnum)
        {
            return false;
        }
        string valueString = value as string;
        if (valueString != null)
        {
            return Enum.IsDefined(type, value) ? Enum.Parse(type, valueString) : null;
        }
        if (value.GetType() == type)
        {
            return value;
        }
        // This appears to handle longs etc
        return Enum.ToObject(type, value);
    }
