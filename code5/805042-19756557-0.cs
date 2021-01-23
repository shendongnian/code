       var timeStamp = "20131101T210705.282Z";
       var datetime = timeStamp.Split(new[] { 'T' ,'.'});
       DateTime dt1;
      
      if (DateTime.TryParseExact(datetime[0],
                         new string[] { "yyyyMMdd" },
                        new CultureInfo("en-US"),
                        DateTimeStyles.None,
                        out dt1))
      {
        Console.WriteLine(dt1.ToShortDateString());
      }
      DateTime dt2;
      if (DateTime.TryParseExact(datetime[1],
                         new string[] { "ssmmhh" },
                        new CultureInfo("en-US"),
                        DateTimeStyles.None,
                        out dt2))
      {
        Console.WriteLine(dt2.ToShortTimeString());
      }
      Console.WriteLine(dt1.ToShortDateString() + " " + dt2.ToShortTimeString());
      Console.ReadLine();
