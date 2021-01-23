    private DateTime getFirstDate(DayOfWeek day, TimeSpan time)
            {
                DateTime date = DateTime.Today;
                while(date.DayOfWeek != day)
                    date.AddDays(1);
    
                return new DateTime(date.Year,date.Month,date.Day,time.Hours,time.Minutes,time.Seconds);
            }
    
