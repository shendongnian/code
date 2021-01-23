    private DateTime FirstDayOfMonth(DateTime date)
    {
        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    }
    
    private DateTime LastDayOfMonth(DateTime date)
    {
        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
    }
