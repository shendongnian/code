    private static readonly TimeZoneInfo IstTimeZone =
       TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    
    public static DateTime ConvertDateTimeUtcToIst(DateTime toConvert)
    {
       return TimeZoneInfo.ConvertTimeFromUtc(toConvert, IstTimeZone);
    }
    
    public static DateTime ConvertDateTimeIstToUtc(DateTime toConvert)
    {
       return TimeZoneInfo.ConvertTimeToUtc(toConvert, IstTimeZone);
    }
