    private static string Calculate(DateTime today)
    {
        DateTime currentDate = today;    
        for (int i = 1; i < 11; i++)
        {
            if ((int)currentDate.DayOfWeek >= 6 || (int)currentDate.DayOfWeek == 0)
                currentDate = currentDate.AddDays(-2);
                currentDate = currentDate.AddDays(-1);
            }
            return currentDate.ToShortDateString();
        }
    }
