    void Main()
    {
        var holidays = new List<DateTime> { new DateTime(2013, 12, 31) };
        GetBusinessMonthDateRange(12, 2013, holidays).Dump();
    }
    
    struct BusinessMonthRange
    {
        public DateTime startDate;
        public DateTime endDate;
    }
    
    BusinessMonthRange GetBusinessMonthDateRange(int month, int year,
        List<DateTime> yearsPublicHolidays)
    {
        DateTime startDate = new DateTime(year, month, 1);
        DateTime endDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
        while (startDate.DayOfWeek == DayOfWeek.Saturday
               || startDate.DayOfWeek == DayOfWeek.Sunday
               || yearsPublicHolidays.Contains(startDate))
        {
            startDate = startDate.AddDays(1);
        }
        while (endDate.DayOfWeek == DayOfWeek.Saturday
               || endDate.DayOfWeek == DayOfWeek.Sunday
               || yearsPublicHolidays.Contains(endDate))
        {
            endDate = endDate.AddDays(-1);
        }
    
        return new BusinessMonthRange { startDate = startDate, endDate = endDate };
    }
