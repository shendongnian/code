    public static string Description(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) 
                                                    as DescriptionAttribute;
        if (descriptionAttribute == null || string.IsNullOrEmpty(descriptionAttribute.Description))
        {
            return value.ToString();
        }
        return descriptionAttribute.Description;
    }
