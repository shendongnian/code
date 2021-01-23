    string[] strings = new[] { "1:23:45.6", "23:45.6", "23:45", "1:23:45" };
    string[] formats = new[] { "H:mm:ss.f", "H:mm.f", "H:mm", "H:mm:ss" };
    TimeSpan[] timespans = strings
        .Select(str =>
        {
            TimeSpan? ts = null;
            DateTime dt;
            if (DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                ts = dt.TimeOfDay;
            return ts;
        })
        .Where(ts => ts.HasValue)
        .Select(ts => ts.Value)
        .ToArray();
