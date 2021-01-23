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
        foreach (var value in Enum.GetValues(typeof(T)).Cast<T>())
        {
            yield return getEnumDescription(value);
        }
    }
    public string getEnumDescription<T>(T value)
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
