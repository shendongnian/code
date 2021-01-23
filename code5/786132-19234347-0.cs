    static int MyParameter(string value, int defaultValue)
    {
        return MyParameter(value, defaultValue, int.Parse);
    }
    static DateTime MyParameter(string value, DateTime defaultValue)
    {
        return MyParameter(value, defaultValue, DateTime.Parse);
    }
    static string MyParameter(string value, string defaultValue)
    {
        return MyParameter(value, defaultValue, x => x);
    }
