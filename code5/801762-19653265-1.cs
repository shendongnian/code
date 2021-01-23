      var data = new Dictionary<DateTime, double>();
      data.Add(new DateTime().AddMinutes(0), 5);
      data.Add(new DateTime().AddMinutes(1), 2);
      data.Add(new DateTime().AddMinutes(3), 1);
      data.Add(new DateTime().AddMinutes(4), 3);
      data.Add(new DateTime().AddMinutes(5), 4);
      data.Add(new DateTime().AddMinutes(6), 5);
      data.Add(new DateTime().AddMinutes(7), 6);
      data.Add(new DateTime().AddMinutes(8), 2);
      data.Add(new DateTime().AddMinutes(9), 4);
      data.Add(new DateTime().AddMinutes(10), 5);
      var result = data.GroupBy(kvp =>
      {
        var dt = kvp.Key;
        var nearest5 = (int)Math.Round(dt.Minute / 5.0) * 5;
        return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, nearest5, 0);
      }).Select(g =>
      {
        return new KeyValuePair<DateTime, double>(g.Key, g.Average(row => row.Value));
      });
      foreach (var r in result)
      {
        Console.WriteLine(r.Key + " " + r.Value);
        //  1/01/0001 12:00:00 AM 3.5
        //  1/01/0001 12:05:00 AM 3.8
        //  1/01/0001 12:10:00 AM 3.66666666666667
      }
