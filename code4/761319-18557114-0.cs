    string d1 = "2013-09-05T15:55";
    string d2 = "09-05T19:10";
 
    string[] formats = new string[] { "yyyy-MM-ddTHH:mm", "MM-ddTHH:mm" };
    List<string> dates = new List<string>() { d1, d2 };
    
    foreach (string date in dates)
    {
        DateTime dt;
        if (DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
        {
            //dt successfully parsed
        }
    }
