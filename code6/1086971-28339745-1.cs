    public static int DaysDiffMinusLeapYears(DateTime dt1, DateTime dt2)
    {
        DateTime startDate = dt1 <= dt2 ? dt1.Date : dt2.Date;
        DateTime endDate = dt1 <= dt2 ? dt2.Date : dt1.Date;
        int days = (endDate - startDate).Days + 1;
        int daysDiff = Enumerable.Range(0, days)
            .Select(d => startDate.AddDays(d))
            .Count(day => day.Day != 29 || day.Month != 2);
        return daysDiff;
    }
