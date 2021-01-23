    static void Main(string[] args)
    {
        TimeZoneInfo tzEastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        TimeZoneInfo tzMountain = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
        // 11/2/2014 02:00 EST should be 11/2/2014 01:00 MDT
        DateTimeOffset dateToTest;
        dateToTest = new DateTimeOffset(2014, 11, 2, 2, 0, 0, TimeSpan.FromHours(-5));
        ShowConversion(dateToTest, tzEastern, tzMountain);
        // 11/2/2014 03:00 EST should be 11/2/2014 01:00 MST
        dateToTest = new DateTimeOffset(2014, 11, 2, 3, 0, 0, TimeSpan.FromHours(-5));
        ShowConversion(dateToTest, tzEastern, tzMountain);
    }
    private static void ShowConversion(DateTimeOffset dateToTest, TimeZoneInfo tzEastern, TimeZoneInfo tzMountain)
    {
        DateTimeOffset convertedTime = TimeZoneInfo.ConvertTime(dateToTest, tzMountain);
        Console.WriteLine("{0:MM/dd/yyyy HH:mm} {1} => {2:MM/dd/yyyy HH:mm} {3}",
            dateToTest, tzEastern.IsDaylightSavingTime(dateToTest) ? "EDT" : "EST",
            convertedTime, tzMountain.IsDaylightSavingTime(convertedTime) ? "MDT" : "MST");
    }
