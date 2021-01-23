    public int NumberTicketsThreeMonthsAgo(IEnumerable<Ticket> tickets)
    {
        var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-3);
        return tickets.Count(t => startDate < t.CreateDateTime);
    }
