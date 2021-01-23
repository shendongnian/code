    private static readonly DateTime _1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public string unixTimeToDateTime(int unixInput, string outputFormat, string timeZoneStandardName)
    {
        var objTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneStandardName);
        var utcDate = _1970.AddSeconds(unixInput);
        DateTime localDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate, objTimeZoneInfo);
        //Perform your output format on localDate
    }
