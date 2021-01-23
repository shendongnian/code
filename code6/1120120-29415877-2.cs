    public static DateTime(int year, int month, DayOfWeek weekDay, int nth)
    {
        DateTime result = new DateTime(year, month, 1);
        while(result.DatOfWeek != weekDay)
            result = result.AddDays(1);
        return result.AddDays(7 * (nth-1));
    }
