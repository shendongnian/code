    public int NumberTicketsThreeMonthsAgo
    {
        DateTime dt = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
                                            1).AddMonths(-3);
        get { return AllTickets.Count(t => dt < t.CreateDateTime); }
    }
