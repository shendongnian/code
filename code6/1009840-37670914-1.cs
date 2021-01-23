    public static int WeekOfYear(DateTime dt)
    {
        int startDays = 0;
        // first day of the year
        DateTime firstJanuary = new DateTime(dt.Year, 1, 1);
        if (firstJanuary.DayOfWeek == DayOfWeek.Tuesday)
        {
            startDays = 1;
        } 
        else if (firstJanuary.DayOfWeek == DayOfWeek.Wednesday)
        {
            startDays = 2;
        }
        else if (firstJanuary.DayOfWeek == DayOfWeek.Thursday)
        {
            startDays = 3;
        }
        else if (firstJanuary.DayOfWeek == DayOfWeek.Friday)
        {
            startDays = 4;
        }
        else if (firstJanuary.DayOfWeek == DayOfWeek.Saturday)
        {
            startDays = 5;
        }
        else if (firstJanuary.DayOfWeek == DayOfWeek.Sunday)
        {
            startDays = 6;
        }
        if (DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek == DayOfWeek.Sunday)
        {
            startDays++;
            startDays = startDays % 7;
        }
    
        return ((dt.DayOfYear + startDays - 1) / 7) + 1;
    }
