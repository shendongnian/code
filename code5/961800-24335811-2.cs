    string[] t1 = "120:15:10".Split(':');
    string[] t2 = "30:10:40".Split(':');
    string[] t3 = "110:30:00".Split(':');
    List<string[]> times = new List<string[]>();
    times.Add(t1);
    times.Add(t2);
    times.Add(t3);
    
    TimeSpan ts = new TimeSpan();
    foreach (var item in times)
    {
        TimeSpan tsa = new TimeSpan(Convert.ToInt32(item[0]), Convert.ToInt32(item[1]), Convert.ToInt32(item[2]));
        ts = (ts == TimeSpan.Zero) ? tsa : ts.Add(tsa);
    }
    Console.WriteLine((ts.Hours + (ts.Days * 24)).ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString());
