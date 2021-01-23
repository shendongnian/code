    public void boldDays()
    {
        List<DateTime> l = new List<DateTime>();
        for(DateTime m = monthCalendar1.SelectionRange.Start;m <= monthCalendar1.SelectionRange.End; m = m.AddDays(1) )
        {
            l.Add(DateTime.Parse(m.ToLongDateString()));
        }
        monthCalendar1.BoldedDates = new DateTime[] { };
        monthCalendar1.BoldedDates = l.ToArray();
    }
