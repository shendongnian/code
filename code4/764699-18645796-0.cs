    List<string> stringList = new List<string>();
    stringList.Add("00:30");
    stringList.Add("01:50");
    stringList.Add("02:00");
    List<TimeSpan> timeSpanList = new List<TimeSpan>();
    TimeSpan ts1 = new TimeSpan(0, 0, 0);
    TimeSpan ts2 = new TimeSpan(0, 0, 0);
    foreach (string item in stringList)
    {
        ts1 = TimeSpan.ParseExact(item, @"mm\:ss", System.Globalization.CultureInfo.CurrentCulture);
        if (ts2.Equals(new TimeSpan(0,0,0)))
        {
            timeSpanList.Add(ts1);
        }
        else
        {
            timeSpanList.Add(ts1 - ts2);
        }
        ts2 = ts1;
    }
