    string s = "2/11/2013 19:14:00";
    DateTime dt;
    if(DateTime.TryParseExact(s, "M/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                              out dt))
    {
      Console.WriteLine(dt.ToString("dd MMMM yyyy HH:mm",
                                     CultureInfo.InvariantCulture));
    }
