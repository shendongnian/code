    public static DateTime AddHalfMonth(DateTime dt, MidpointRounding rounding)
    {
        int daysInMonth = System.DateTime.DaysInMonth(dt.Year, dt.Month);
        if(daysInMonth % 2 == 0)
            return dt.AddDays(daysInMonth / 2);
        else if(rounding == MidpointRounding.ToEven)
            return dt.AddDays(daysInMonth / 2);
        else
            return dt.AddDays((daysInMonth + 1) / 2);
    }
