    DateTime start = DateTime.Today.AddDays(-50);
    var sortedList = new SortedList<DateTime, string>();
    for(int i = 0; i < 50; i+=2)
    {
        var dt = start.AddDays(i);
        sortedList.Add(dt, string.Format("Date #{0}: {1}", i, dt.ToShortDateString()));
    }
    DateTime low = start.AddDays(1);   // is not in the SortedList which contains only every second day
    DateTime high = start.AddDays(10);
