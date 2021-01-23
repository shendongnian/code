    private enum Days
    {
        [Description("Saturday")]
        Sat,
        [Description("Sunday")]
        Sun,
        [Description("Monday")]
        Mon,
        [Description("Tuesday")]
        Tue,
        [Description("Wednesday")]
        Wed,
        [Description("Thursday")]
        Thu,
        [Description("It's Friday, Friday, gotta get down on Friday")]
        Fri
    };
    public static string DescribeEnum(Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(
            field, typeof(DescriptionAttribute));
        return (descriptionAttribute == null)
                   ? value.ToString()
                   : descriptionAttribute.Description;
    }
    private static void Main()
    {
        Console.WriteLine(DescribeEnum(Days.Fri));
        // Output:
        // It's Friday, Friday, gotta get down on Friday
    }
