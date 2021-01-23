    string s = "2012-09-30T23:00:00.0000000Z";
    var date = DateTime.ParseExact(s, "o", CultureInfo.InvariantCulture,
                                       DateTimeStyles.AssumeUniversal |
                                       DateTimeStyles.AdjustToUniversal);
    Console.WriteLine(date);
