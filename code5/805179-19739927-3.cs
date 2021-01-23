     var days = Enumerable
                .Range(0, (int)d2.Subtract(d1).TotalDays)
                .Select(x => d1.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
    Console.Writeline("Number of Weekdays is {0}",d(dateFrom, dateTo));
