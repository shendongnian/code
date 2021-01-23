    public static bool DateInsideOneWeek(DateTime checkDate, DateTime referenceDate)
    {
        // get first day of week from your actual culture info, 
        DayOfWeek firstWeekDay = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        // or you can set exactly what you want: firstWeekDay = DayOfWeek.Monday;
        // calculate first day of week from your reference date
        DateTime startDateOfWeek = referenceDate;
        while(startDateOfWeek.DayOfWeek != firstWeekDay)
        { startDateOfWeek = startDateOfWeek.AddDays(-1d); }
        // fist day of week is find, then find last day of reference week
        DateTime endDateOfWeek = startDateOfWeek.AddDays(6d);
        // and check if checkDate is inside this period
        return checkDate >= startDateOfWeek && checkDate <= endDateOfWeek;
    }
