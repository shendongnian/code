    public static IEnumerable<DateRange> GetWeekdayRange(DateTime startDate, DateTime endDate, DayOfWeek weekStartsOn = DayOfWeek.Monday)
    {
        var diff = endDate.Subtract(startDate).Days;
        var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
        var range = Enumerable.Range(0,diff+1).Select(v => startDate.AddDays(v))
                            .Select(d => new {Date=d, WeekNumber=cal.GetWeekOfYear(d, System.Globalization.CalendarWeekRule.FirstDay, weekStartsOn) })
                            .GroupBy(g => g.WeekNumber);
        
        return range.Select(g => new DateRange{WeekStartDate=g.Min(v => v.Date), WeekEndDate= g.Max(v => v.Date)});
    }
