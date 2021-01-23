    public static IEnumerable<DateTime> GetMonths(int count)
    {
        // Note: this uses the system local time zone. Are you sure that's what
        // you want?
        var today = DateTime.Today;
        // Always return the 1st of the month, so we don't need to worry about
        // what "March 30th - 1 month" means
        var startOfMonth = new DateTime(today.Year, today.Month, 1);
        for (int i = 0; i < count; i++)
        {
            yield return startOfMonth;
            startOfMonth = startOfMonth.AddMonths(-1);
        }
    }
