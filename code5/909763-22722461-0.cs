    public double ConvertTime(double inTime, string sourceTZ, string destTZ)
    {
        DateTime sourceDT = DateTime.FromOADate(inTime);
        TimeZoneInfo sourceTZI = TimeZoneInfo.FindSystemTimeZoneById(sourceTZ);
        TimeZoneInfo destTZI = TimeZoneInfo.FindSystemTimeZoneById(destTZ);
        DateTime destDT = TimeZoneInfo.ConvertTime(sourceDT, sourceTZI, destTZI);
        return destDT.ToOADate();
    }
