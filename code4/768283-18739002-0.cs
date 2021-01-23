    public static string GetDescription<TEnum>(this TEnum value)
    {
	    var attributes = value.GetAttributes<DescriptionAttribute>();
	    if (attributes.Length == 0)
	    {
	       return Enum.GetName(typeof(TEnum), value);
	    }
	    return attributes[0].Description;
    }
