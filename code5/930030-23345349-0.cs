    DateTime GetDay(DateTime startDate, DayOfWeek targetDay)
    {
        var date = startDate;
        while (date.DayOfWeek != targetDay)
        {
            date = date.AddDays(-1);
        }
        return date;
    }
