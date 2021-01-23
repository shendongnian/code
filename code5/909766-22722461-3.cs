    public double ConvertFromLocalTime(double inTime, string destTZ)
    {
        DateTime sourceDT = DateTime.FromOADate(inTime);
        TimeZoneInfo sourceTZI = TimeZoneInfo.Local;
        TimeZoneInfo destTZI = TimeZoneInfo.FindSystemTimeZoneById(destTZ);
        DateTime destDT = TimeZoneInfo.ConvertTime(sourceDT, sourceTZI, destTZI);
        return destDT.ToOADate();
    }
