    static void Test5()
    {
        DateTime start = new DateTime(2014, 1, 29);
        DateTime nextDate = start;
        for (int i = 0; i < 5; i++)
        {
            nextDate = nextDate.AddMonths(1);
                
            if (start.Day == DateTime.DaysInMonth(start.Year, start.Month))
            {
                // If the start date was the end of the month, then set the generated date to end of the month as well
                // e.g. 31/1 -> 28/2 -> 31/3 -> 30/4 -> 31/5 ... and so on
                int endDay = DateTime.DaysInMonth(nextDate.Year, nextDate.Month);
                nextDate = new DateTime(nextDate.Year, nextDate.Month, endDay);
            }
            else
            {
                // Try to set the day to same as start day
                if (start.Day <= DateTime.DaysInMonth(nextDate.Year, nextDate.Month))
                {
                    nextDate = new DateTime(nextDate.Year, nextDate.Month, start.Day);
                }
            }
                
            Console.WriteLine(nextDate.ToString("dd/MM/yyyy"));
        }
    }
