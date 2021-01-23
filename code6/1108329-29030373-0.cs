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
            current = current.AddDays(1);
            if (current.DayOfWeek == DayOfWeek.Sunday ||
                current.DayOfWeek == DayOfWeek.Saturday)
            {
                // Effectively force "go round again" behaviour.
                i--;
            }
        }
        return current;
    }
