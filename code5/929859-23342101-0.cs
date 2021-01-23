    public static string GetDescription(EnumName value)
    {
        var enumtotal = Enum.GetValues(typeof(EnumName)).Cast<int>().Sum(); //this could be buffered for performance
        if ((enumtotal | (int)value) == enumtotal)
            return value.ToString();
        return ((int)value).ToString("X8");
    }
