    IEnumerable<DateTime> Payday(DateTime startDate, int howMany)
    {
        int count = 0, mondays = 0;
    
        while (count < howMany)
        {
            startDate = startDate.AddDays(1);
    
            if (startDate.DayOfWeek == DayOfWeek.Monday && mondays == 0)
            {
                mondays++;
            }
            else if (startDate.DayOfWeek == DayOfWeek.Monday)
            {
                mondays = 0;
                count++;
                yield return startDate;
            }
        }
    }
