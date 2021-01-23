    public void boldDays()
    {
        List<DateTime> l = new List<DateTime>();
        foreach (var event in savedEvents)
        {
            l.Add(event.Date);
        }
        monthCalendar1.BoldedDates = l.ToArray();
    }
