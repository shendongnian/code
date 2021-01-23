    void WriteRows(TimeClockDataContext context, EditTime[] rows)
    {
        foreach (var row in rows)
        {
            destinationContext.tblEditTimes.Add(row);
        }
        destinationContext.SubmitChanges();
    }
