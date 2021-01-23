    GetWorkingDays d = (dateFrom, dateTo) =>
        {
         return Enumerable
                .Range(1, (int)dateTo.Subtract(dateFrom).TotalDays)
                .Select(x => to.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
        }
    Console.Writeline("Number of Weekdays is {0}",d(dateFrom, dateTo));
