    private static string GetBSTTimeStamp(string timestamp)
    {
        DateTime dt = DateTime.Parse(timestamp);
        //TimeZoneInfo bst = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        //Console.WriteLine("Time zone supports dls? {0}", bst.SupportsDaylightSavingTime);
        //Console.WriteLine("Time zone offset? {0}", bst.BaseUtcOffset);
        DateTime dateTimeInUtc = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dt, "Eastern Standard Time", "GMT Standard Time");
        return dateTimeInUtc.ToString();
    }
