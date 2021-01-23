            DateTime calendarMonth = new DateTime(2013, 10, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime startDay = calendarMonth.AddDays(-1);
            DateTime endDay = calendarMonth.AddMonths(1);
            while (startDay <= endDay)
            {
                Console.WriteLine(startDay + " = " + startDay.ToUniversalTime());
                startDay = startDay.AddDays(1);
            }
