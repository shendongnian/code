    string[] formats = new string[] { "yyyyMMdd", "yyyyMM", "yyyy" };
    string[] inputs = new string[] { "2012", "201201", "20120101" };
    foreach (var s in inputs)
    {
        Console.WriteLine(DateTime.ParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
    }
    public static DateTime ConvertToDateTime(int intDateTime)
    {
        return DateTime.ParseExact(intDateTime.ToString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
    }
