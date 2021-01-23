    public void SetDates(DateTime startDate, EndDate endDate)
    {
        if (startDate <= endDate)
        {
            start = startDate;
            end = endDate;
        }
        else
        {
            throw new InvalidDates();
        }
    }
