    DateTime startDate = new DateTime(2014, 04, 06, 11, 30, 0, 0, 0);
    DateTime endDate = new DateTime(2014, 04, 08, 10, 15, 0, 0, 0);
    TimeSpan StartOfDay = new TimeSpan(9, 0, 0);
    TimeSpan EndOfDay = new TimeSpan(17, 0, 0);            
    int minuteCount = 0;
    while ((endDate - startDate).Minutes >= 0)
    {
        if (startDate.DayOfWeek >= DayOfWeek.Monday && startDate.DayOfWeek <= DayOfWeek.Friday)
            if (startDate.TimeOfDay > StartOfDay && startDate.TimeOfDay <= EndOfDay)                        
                secondCount++;
        startDate = startDate.AddSeconds(1);
    }
    Console.WriteLine("Total Hours and Minutes: " + new TimeSpan(0, minuteCount, 0));
