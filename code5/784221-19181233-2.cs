    public static IEnumerable<DateTime> MonthsBetween(int startMonth, int startYear, int endMonth, int endYear)
    {
        for
        (
            DateTime date = new DateTime(startYear, startMonth, 01);
            date <= new DateTime(endYear, endMonth, 01);
            date = date.AddMonths(1)
        )
        {
            yield return date;
        }
    }
