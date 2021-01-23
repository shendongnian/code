    public static DateTime ConvertDateTimeUtcToIst(
                              DateTime toConvert, int offset = 0)
    {
       return TimeZoneInfo.ConvertTimeFromUtc(toConvert, IstTimeZone)
                 .AddMinutes(offset);
    }
    
    public static DateTime ConvertDateTimeIstToUtc(
                              DateTime toConvert, int offset = 0)
    {
       return TimeZoneInfo.ConvertTimeToUtc(toConvert, IstTimeZone)
                 .AddMinutes(offset);
    }
