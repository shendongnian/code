    public static class Extensions
    {
        public static List<MonthDaysData> GetWorkingDaysPerMonthTo(this DateTime from, 
                             DateTime to)
        {
            var workings = new Dictionary<int, int>();
            var currentDateTime = from;
    
            while (currentDateTime <= to)
            {
                if (currentDateTime.DayOfWeek != DayOfWeek.Saturday 
                                      && currentDateTime.DayOfWeek != DayOfWeek.Sunday 
                                      && !currentDateTime.IsHoliday("CountryCode"))
                    if (!workings.ContainsKey(currentDateTime.Month))
                        workings.Add(currentDateTime.Month, 1);
                    else
                    {
                        int curWork;
                        workings.TryGetValue(currentDateTime.Month, out curWork);
                        curWork++;
                        workings.Remove(currentDateTime.Month);
                        workings.Add(currentDateTime.Month, curWork);
                    }
    
                currentDateTime = currentDateTime.AddDays(1);
            }
            return workings.Select(work => new MonthDaysData {Month = work.Key, 
                                                           days = work.Value}).ToList();
        } 
        public static bool IsHoliday(this DateTime date, string countryCode)
        {
            // some service that takes a country code and 
            // returns true/false if its a holiday
            return false;
        }
    }
