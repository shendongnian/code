    // starting from this string
    string s = "26:00:00";
    // Parse as a Duration using the Noda Time Pattern API
    DurationPattern pattern = DurationPattern.CreateWithInvariantCulture("H:mm:ss");
    Duration d = pattern.Parse(s).Value;
    Debug.WriteLine(pattern.Format(d));  // 26:00:00
    // if you want a TimeSpan, you can still get one.
    TimeSpan ts = d.ToTimeSpan();
    Debug.WriteLine(ts);  // 1.02:00:00
