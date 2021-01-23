    string s = "10/20/1983 00:00:00";
    string format = "MM/dd/yyyy HH:mm:ss";
    DateTime dt;
    if (DateTime.TryParseExact(s, format, CultureInfo.GetCultureInfo("en-GB"),
                               DateTimeStyles.None, out dt))
    {
        Console.WriteLine(dt);
    }
