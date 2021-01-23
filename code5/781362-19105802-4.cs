    static class HolidayTester
    {
        private static HashSet<DateTime> fixedHolidays = new HashSet<DateTime>(new DayOnlyComparer())
            {
                new DateTime(1900,1,1), //New Years
                new DateTime(1900,7,4), //4th of july
                new DateTime(1900,12, 25) //Christmas
            };
        /// <summary>
        /// Finds the most recent workday from a given date.
        /// </summary>
        /// <param name="date">The date to test.</param>
        /// <returns>The most recent workday.</returns>
        public static DateTime GetLastWorkday(DateTime date)
        {
            //Test for a non working day
            if (IsDayOff(date))
            {
                //We hit a non working day, recursively call this function again on yesterday.
                return GetLastWorkday(date.AddDays(-1));
            }
            //Not a holiday or a weekend, return the current date.
            return date;
        }
        /// <summary>
        /// Returns if the date is work day or not.
        /// </summary>
        /// <param name="testDate">Date to test</param>
        /// <returns>True if the date is a holiday or weekend</returns>
        public static bool IsDayOff(DateTime testDate)
        {
          return date.DayOfWeek == DayOfWeek.Saturday ||
                 date.DayOfWeek == DayOfWeek.Sunday || //Test for weekend
                 IsMovingHolidy(testDate) || //Test for a moving holiday
                 fixedHolidays.Contains(testDate); //Test for a fixed holiday
        }
        /// <summary>
        /// Tests for each of the "dynamic" holidays that do not fall on the same date every year.
        /// </summary>
        private static bool IsMovingHolidy(DateTime testDate)
        {
            //Memoral day is the last Monday in May
            if (testDate.Month == 5 && //The month is May 
                    testDate.DayOfWeek == DayOfWeek.Monday && //It is a Monday
                    testDate.Day > (31 - 7)) //It lands within the last week of the month.
                return true;
            //Labor day is the first Monday in September
            if (testDate.Month == 9 && //The month is september
                    testDate.DayOfWeek == DayOfWeek.Monday &&
                    testDate.Day <= 7) //It lands within the first week of the month
                return true;
            //Thanksgiving is the 4th Thursday in November
            if (testDate.Month == 11 && //The month of November
                testDate.DayOfWeek == DayOfWeek.Thursday &&
                testDate.Day > (7*3) && testDate.Day <= (7*4)) //Only durning the 4th week
                return true;
            
            return false;
        }
        /// <summary>
        /// This comparer only tests the day and month of a date time for equality
        /// </summary>
        private class DayOnlyComparer : IEqualityComparer<DateTime>
        {
            public bool Equals(DateTime x, DateTime y)
            {
                return x.Day == y.Day && x.Month == y.Month;
            }
            public int GetHashCode(DateTime obj)
            {
                return obj.Month + (obj.Day * 12);
            }
        }
    }
