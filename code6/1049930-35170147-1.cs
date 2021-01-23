    public enum Test
    {
        [Description("This")]
        A,
        B,
        C,
        D
    }
    private IEnumerable<string> GetEnumDescription<T>()
    {
        var type = typeof(T);
        if (!type.IsEnum) throw new ArgumentException("Only Enum types allowed");
        foreach (var value in Enum.GetValues(type).Cast<Enum>())
        {
            yield return getEnumDescription(value);
        }
    }
    public string getEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return value.ToString();
        }
    }
   
