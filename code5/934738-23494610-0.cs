    public static DateTime DateTimeConvert(DateTime nonConvertedDateTime, string timeoffsetvalue, string timeZoneToConvertTo)
        {
            TimeZoneInfo tzinfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneToConvertTo);
            DateTime dtDateTime = nonConvertedDateTime.AddMinutes(Convert.ToInt32(timeoffsetvalue));
            dtDateTime = TimeZoneInfo.ConvertTimeFromUtc(dtDateTime, tzinfo);
            return dtDateTime;
        }
    Console.WriteLine(DateTimeConvert(new DateTime(2014, 5, 6, 8, 00, 00), "240", "India Standard Time").ToString());
    Console.WriteLine(DateTimeConvert(new DateTime(2014, 5, 6, 8, 00, 00), "240", "Central Standard Time").ToString());
