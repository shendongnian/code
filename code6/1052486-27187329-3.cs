    TimeSpan[] spans = {TimeSpan.FromHours(0), TimeSpan.FromHours(6),TimeSpan.FromHours(12),TimeSpan.FromHours(18)};
    var now = DateTime.Today;  // midnight
    var list = new List<DateTime> { now.AddMinutes(-99), now.AddMinutes(+100), now.AddMinutes(199), now.AddMinutes(-200) };
    for (int i = 0; i < list.Count; i+=2)
    {
        DateTime dt1 = list[i];
        DateTime dt2 = list[i + 1];
        IEnumerable<DateTime> nearestToMidNight = GetNearestToTime(spans[0], dt1, dt2);
        Console.WriteLine("{0} nearest: {1}", spans[0], string.Join(",", nearestToMidNight));
        // and so on with the other timespans...
    }
