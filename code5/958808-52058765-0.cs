    public DateTime GetLastDayOfTheMonth()
        {
            int daysFromNow = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - (int)DateTime.Now.Day;
            return DateTime.Now.AddDays(daysFromNow);
        }
