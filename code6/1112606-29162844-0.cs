    public static IEnumerable<DateRange> GetWeekdayRange(DateTime startDate, DateTime endDate, DayOfWeek weekEndsOn = DayOfWeek.Sunday)
    {
        var currStartDate = startDate;
        var currDate = startDate;
        while(currDate<endDate)
        {
            while(currDate.DayOfWeek != weekEndsOn && currDate<endDate)
            {
                currDate = currDate.AddDays(1);
            }
            yield return new DateRange{ WeekStartDate = currStartDate,WeekEndDate = currDate};
            currStartDate = currDate.AddDays(1);
            currDate = currStartDate;
        }
    }
    public struct DateRange
    {
        public DateTime WeekStartDate{get;set;}
        public DateTime WeekEndDate{get;set;}
    }
