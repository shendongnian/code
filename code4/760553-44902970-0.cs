    List<string> inputs = new List<string> { "78", "10545", "5" };
    IEnumerable<TimeSpan> timeSpans = inputs
        .Select(i => TryParseTimeSpan(i))
        .Where(ts => ts.HasValue)
        .Select(ts => ts.Value);
    foreach (TimeSpan ts in timeSpans)
        Console.WriteLine(ts.ToString());
