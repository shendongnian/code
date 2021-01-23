    string s = "2005";
    DateTime dt;
    if(DateTime.TryParseExact(s, "yyyy", CultureInfo.InvariantCulture,
                              DateTimeStyles.None, out dt))
    {
         Console.WriteLine(dt);
    }
