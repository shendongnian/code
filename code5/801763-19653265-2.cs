      var data = new Dictionary<DateTime, double>();
      data.Add(new DateTime(2012, 1, 1, 23, 53, 0), 5);
      data.Add(new DateTime(2012, 1, 1, 23, 54, 0), 2);
      data.Add(new DateTime(2012, 1, 1, 23, 55, 0), 1);
      data.Add(new DateTime(2012, 1, 1, 23, 56, 0), 3);
      data.Add(new DateTime(2012, 1, 1, 23, 57, 0), 4);
      data.Add(new DateTime(2012, 1, 1, 23, 58, 0), 5);
      data.Add(new DateTime(2012, 1, 1, 23, 59, 0), 6);
      data.Add(new DateTime(2012, 1, 2, 0, 0, 0), 2);
      data.Add(new DateTime(2012, 1, 2, 0, 1, 0), 4);
      data.Add(new DateTime(2012, 1, 2, 0, 2, 0), 5);
      var result = data.GroupBy(kvp =>
      {
        var dt = kvp.Key;
        var nearest5 = (int)Math.Round(dt.Minute / 5.0) * 5;
        //Add the minutes after inital date creation to deal with minutes=60
        return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0).AddMinutes(nearest5);
      })
      .Select(g =>
      {
        return new KeyValuePair<DateTime, double>(g.Key, g.Average(row => row.Value));
      });
      foreach (var r in result)
      {
        Console.WriteLine(r.Key + " " + r.Value);
        //  1/01/2012 11:55:00 PM 3
        //  2/01/2012 12:00:00 AM 4.4
      }
