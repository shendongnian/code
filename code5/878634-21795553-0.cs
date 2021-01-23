    public static int GetAmountBetween(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
    {
        int addAmount = 0;
        switch (dayOfWeek)
        {
            case DayOfWeek.Monday:
                addAmount = 0;
                break;
            case DayOfWeek.Tuesday:
                addAmount = 1;
                break;
            case DayOfWeek.Wednesday:
                addAmount = 2;
                break;
            case DayOfWeek.Thursday:
                addAmount = 3;
                break;
            case DayOfWeek.Friday:
                addAmount = 4;
                break;
            case DayOfWeek.Saturday:
                addAmount = 5;
                break;
            case DayOfWeek.Sunday:
                addAmount = 6;
                break;
        }
        
        return (endDate.Subtract(startDate).Days + addAmount) / 7; 
    }
