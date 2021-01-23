    // With time zone set for US Pacific time, there should only be 23 hours
    // between these two points
    DateTime a = new DateTime(2013, 03, 10, 0, 0, 0, DateTimeKind.Local);
    DateTime b = new DateTime(2013, 03, 11, 0, 0, 0, DateTimeKind.Local);
    TimeSpan t = b - a;
    Debug.WriteLine(t.TotalHours);  // 24
