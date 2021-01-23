    public static DateTime GetDateIn(int numWorkingHours)
    {
        int numDays = numWorkingHours / 8;
        DateTime date = DateTime.Now;
        // normalize to monday
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            date = date.AddDays(date.DayOfWeek == DayOfWeek.Sunday ? 1 : 2); 
        int weeks = numDays / 5;
        int remainder = numDays % 5;
        date = date.AddDays(weeks * 7 + remainder);  
        // normalize to monday
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            date = date.AddDays(date.DayOfWeek == DayOfWeek.Sunday ? 1 : 2);    
        return date;
    }
