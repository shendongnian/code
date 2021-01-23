    public object ToEnum(Type enumType, object value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        if (enumType == null)
        {
            throw new ArgumentNullException("type");
        }
        if (!enumType.IsEnum)
        {
            return false;
        }
        string valueString = value as string;
        if (valueString != null)
        {
            return Enum.IsDefined(enumType, value) ? Enum.Parse(enumType, valueString) : null;
        }
        if (value.GetType() == enumType)
        {
            return value;
        }
        // This appears to handle longs etc
        return Enum.ToObject(enumType, value);
    }
