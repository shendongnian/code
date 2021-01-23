    public void boldDays()
    {
        List<DateTime> l = new List<DateTime>();
        for(DateTime m = monthCalendar1.SelectionRange.Start;m <= monthCalendar1.SelectionRange.End; m = m.AddDays(1) )
        {
            l.Add(DateTime.Parse(m.ToLongDateString()));
        }
        //monthCalendar1.BoldedDates = new DateTime[] { };
        l.AddRange(monthCalendar1.BoldedDates); //If you want to preserve previously added dates then add previously added dates to list as  
        monthCalendar1.BoldedDates = l.ToArray();
    }
