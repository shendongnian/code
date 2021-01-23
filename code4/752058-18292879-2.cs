    static DateTimeOffset ConvertUtcTimeToTimeZone(DateTime dateTime, string toTimeZoneDesc)
    {
       TimeZoneInfo timeZoneInfo; 
       DateTime dateTime ;
       timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(toTimeZoneDesc);
       dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
       return new DateTimeOffset(dateTime);
    }
