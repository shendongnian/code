    public override string UserTextOp
    {
        get
        {
            Type enumType = typeof(enumTextCond);
            string name = Enum.GetName(enumType, cond1SelectedKeyEnum);
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
                return name;
            }
            return string.Empty;
    
        }
    }
