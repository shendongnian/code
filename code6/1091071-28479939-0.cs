    public static DateTime Next(this DateTime datetime, DayOfWeek day)
    {
        return datetime.AddDays(datetime.DayOfWeek < day ?
            day - datetime.DayOfWeek :
            7 + day - datetime.DayOfWeek);
    }
