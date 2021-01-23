        public static int MondaysInMonth(DateTime thisMonth)
    {
        int mondays = 0;
        int month = thisMonth.Month;
        int year = thisMonth.Year;
        int daysThisMonth = DateTime.DaysInMonth(year, month);
        DateTime beginingOfThisMonth = new DateTime(year, month, 1);
        for (int i = 0; i < daysThisMonth; i++)
            if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                mondays++;
        return mondays;
    }
