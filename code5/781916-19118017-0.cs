    public static DateTime GetNextDay(DayOfWeek day)
    {
        DateTime start = DateTime.Today.AddDays(1);
        int days = ((int)day - (int)start.DayOfWeek + 7) % 7;
    
        return start.AddDays(days);
    }
