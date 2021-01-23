    private List<DateTime> GetDates(DateTime startDate, DateTime endDate)
    {
        var returnDates = new List<DateTime>();
        for (DateTime dateCounter = startDate; dateCounter < endDate; dateCounter = dateCounter.AddDays(1))
        {
            returnDates.Add(dateCounter);
        }
        return returnDates;
    }
