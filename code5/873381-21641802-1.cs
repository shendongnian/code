    string json = "0001-01-01T00:00:00+00:00";
    DateTime dt1;
    if (DateTime.TryParse(json, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt1))
    {
        Debug.Assert(dt1.Kind == DateTimeKind.Local);
        Console.WriteLine("1: " + (dt1 == DateTime.MinValue));  // fails
    }
    DateTime dt2;
    if (TryParseIso8601(json, out dt2))
    {
        Debug.Assert(dt2.Kind == DateTimeKind.Utc);
        Console.WriteLine("2: " + (dt2 == DateTime.MinValue));
    }
    DateTime local = new DateTime(2014, 02, 02, 0, 0, 0, DateTimeKind.Local);
    Debug.Assert(local.Kind == DateTimeKind.Local);
    string json2 = local.ToString("yyyy-MM-ddTHH:mm:sszzz");
    DateTime dt3;
    if (DateTime.TryParse(json2, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt3))
    {
        Debug.Assert(dt3.Kind == DateTimeKind.Local);
        Console.WriteLine("3: " + (dt3 == local));
    }
    DateTime dt4;
    if (TryParseIso8601(json2, out dt4))
    {
        Debug.Assert(dt4.Kind == DateTimeKind.Utc);
        Console.WriteLine("4: " + (dt4 == local.ToUniversalTime()));
    }
    DateTime utc = new DateTime(2014, 02, 02, 0, 0, 0, DateTimeKind.Utc);
    Debug.Assert(utc.Kind == DateTimeKind.Utc);
    string json3 = local.ToString("yyyy-MM-ddTHH:mm:ssZ");
    DateTime dt5;
    if (DateTime.TryParse(json3, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt5))
    {
        Debug.Assert(dt5.Kind == DateTimeKind.Utc);
        Console.WriteLine("5: " + (dt5 == utc));
    }
    DateTime dt6;
    if (TryParseIso8601(json3, out dt6))
    {
        Debug.Assert(dt6.Kind == DateTimeKind.Utc);
        Console.WriteLine("6: " + (dt6 == utc));
    }
    string json4 = "2014-02-02T00:00:00+00:00";
    DateTime dt7;
    if (DateTime.TryParse(json4, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt7))
    {
        Debug.Assert(dt7.Kind == DateTimeKind.Local);
        Console.WriteLine("7: " + (dt7.ToUniversalTime() == utc));
    }
    DateTime dt8;
    if (TryParseIso8601(json4, out dt8))
    {
        Debug.Assert(dt8.Kind == DateTimeKind.Utc);
        Console.WriteLine("8: " + (dt8 == utc));
    }
