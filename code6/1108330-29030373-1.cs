    static DateTime AddDaysExcludingWeekends(DateTime start, int days)
    {
        // Do you need this?
        if (days < 0)
        {
            throw new ArgumentException("Not implemented yet...");
        }
        DateTime current = start;
        for (int i = 0; i < days; days++)
        {
            // Loop at least once, and keep going until we're on
            // a weekday.
            do
            {
               current = current.AddDays(1);
            }
            while (current.DayOfWeek == DayOfWeek.Sunday ||
                   current.DayOfWeek == DayOfWeek.Saturday);
        }
        return current;
    }
