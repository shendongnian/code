    public static void Main()
    {
        var daylightTime = GetDaylightChanges("Pacific Standard Time", DateTime.Today.Year);
        var dylightTime2 = TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.Today.Year);
    }
