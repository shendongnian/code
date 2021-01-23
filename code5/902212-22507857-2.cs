        private static void GetDates()
        {
            var lstYears = new List<int>();
            
            int iYearNow = DateTime.Now.Year;
            for (int year = iYearNow; year > iYearNow - 115; year--)
            {
                lstYears.Add(year);
            }
            var lstMonthWdays = new List<int[]>();
            for (int month = 1; month < 13; month++)
            {
                lstMonthWdays.Add(new int[] { month, DateTime.DaysInMonth(iYearNow, month) });
            }
        }
