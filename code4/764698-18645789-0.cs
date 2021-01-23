    One solution:
    string[] lapTimes = { "00:30", "1:50", "2:00"};
    var laps = lapTimes.Select(s => s.Split(":".ToCharArray()));
    var times = laps.Select(s=> new TimeSpan(0, int.Parse(s[0]), int.Parse(s[1]))).Reverse();
    List<TimeSpan> diffs = new List<TimeSpan>();
    for (int i = 0; i < times.Count() - 1; i++)
    {
        diffs.Add(times.ElementAt(i) - times.ElementAt(i+1));            
    }
