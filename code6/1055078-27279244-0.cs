    public static Dictionary<T, string> EnumToDictionary<T>()
        where T : struct
    {
        Type enumType = typeof(T);
    
        // Can't use generic type constraints on value types,
        // so have to do check like this
        if (enumType.BaseType != typeof(Enum))
            throw new ArgumentException("T must be of type System.Enum");
    
        Dictionary<T, string> enumDL = new Dictionary<T, string>();
        foreach (T enm in Enum.GetValues(enumType))
        {
            string name = Enum.GetName(enumType, enm);
            if (name != null)
            {
                FieldInfo field = enumType.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                            Attribute.GetCustomAttribute(field,
                                typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                        name = attr.Description;
                }
            }
            enumDL.Add(enm, name);
        }
        return enumDL;
    }
