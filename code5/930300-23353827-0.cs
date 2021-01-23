    public static int MondaysInMonth(DateTime thisMonth)
    {
        int mondays = 0;
        int month = thisMonth.Month;
        int year = thisMonth.Year;
        int daysThisMonth = DateTime.DaysInMonth(year, month);
        DateTime beginnngOfThisMonth = new DateTime(year, month, 1);
        for (int i = 1; i < daysThisMonth + 1; i++)
            if (beginnngOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                mondays++;
        return mondays;
    }
