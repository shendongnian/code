    public static string GetDescription(this Enum value)
    {
        Type type = value.GetType();
        string name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo field = type.GetField(name);
            if (field != null)
            {
                MyDescription attr = 
                       Attribute.GetCustomAttribute(field, 
                         typeof(MyDescription)) as MyDescription;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
        }
        return null;
    }
