    public static string GetDescription(num Enumeration)
    {
         string Value = Enumeration.ToString();
         Type EnumType = Enumeration.GetType();
         var DescAttribute = (DescriptionAttribute[])EnumType
                .GetField(Value)
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
         return DescAttribute.Length > 0 ? DescAttribute[0].Description : Value;
    }
