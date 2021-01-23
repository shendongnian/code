    public int NumberTicketsThreeMonthsAgo
    {
        get 
        {
            var earliestDate = new DateTime(DateTime.Today.Year, 
                                            DateTime.Today.Month,
                                            1).AddMonths(-3);
            return AllTickets.Count(t => earliestDate < t.CreateDateTime); 
        }
    }
