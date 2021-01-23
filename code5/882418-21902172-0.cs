    private DateTime GetNthDay(int n)
    {
        DateTime today  = DateTime.Today;
        DateTime nthDay = new DateTime(today.Year, today.Month, n);
        if ( nthDay <= today )
        {
            nthDay = nthDay.AddMonths(1);
        }
        return nthDay;
    }
