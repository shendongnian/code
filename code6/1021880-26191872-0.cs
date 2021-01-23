    DateTime[] times = new DateTime[6];
    times[0] = new DateTime(2014, 09, 1, 11, 54, 40);
    times[1] = new DateTime(2014, 09, 1, 11, 55, 45);
    times[2] = new DateTime(2014, 09, 1, 11, 57, 40); // Minute 57
    times[3] = new DateTime(2014, 09, 1, 12, 00, 10); // Minute 00 but next hour
    times[4] = new DateTime(2014, 09, 1, 12, 01, 34);
    times[5] = new DateTime(2014, 09, 1, 12, 12, 16);
    
    DateTime t = times[0];
    t = new DateTime(t.Year, t.Month, t.Day, t.Hour, t.Minute, 0);
    int i = 0;
    while (i < times.Length) {
      if (times[i] < t) {
        Console.WriteLine(times[i++]);
      } else {
        if (times[i] < t.AddMinutes(1)) {
          Console.WriteLine(times[i++]);
        } else {
          Console.WriteLine(t);
        }
        t = t.AddMinutes(1);
      }
    }
