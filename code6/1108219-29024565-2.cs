      String dbTime = "2015.02.21 1:00 AM"; // <= A sample time
      DateTime time = DateTime.Parse(dbTime); // <= Convert it to a datetime
      TimeZoneInfo eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");  // <= TimeZoneInfo for Eastern
      TimeZoneInfo local = TimeZoneInfo.Local; // <=TimeZoneInfor for local
      Console.WriteLine(TimeZoneInfo.ConvertTime(time, estern, local)); // Will return the Local time related to provided to Eastern Time
