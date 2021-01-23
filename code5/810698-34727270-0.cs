     public DateTime FirstDateOfWeek(
            int year,
            int weekOfYear)
        {
            var newYear = new DateTime(year, 1, 1);
            var weekNumber = newYear.GetIso8601WeekOfYear(); 
            DateTime firstWeekDate;
            if (weekNumber != 1)
            {
                var dayNumber = (int) newYear.DayOfWeek;
                firstWeekDate = newYear.AddDays(7 - dayNumber + 1);
            }
            else
            {
                var dayNumber = (int)newYear.DayOfWeek;
                firstWeekDate = newYear.AddDays(-dayNumber + 1);
            }
            if (weekOfYear == 1)
            {
                return firstWeekDate;
            }
            return firstWeekDate.AddDays(7 * (weekOfYear - 1));
        }
