    public static int InstallmentCount(DateTime start, DateTime end)
    {
        return Days(start, end)
            .Where(day => IsLastDayOfMonth(day))
            .Count();
    }
