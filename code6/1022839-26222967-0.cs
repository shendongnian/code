    string str = "10/14/2014 8:30 AM (America/Los Angeles)";
    string newStr = string.Join(" ", str.Split().Take(3));
    DateTime parsingDateTime;
    if (!DateTime.TryParseExact(newStr, "M/d/yyyy h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None,
        out parsingDateTime))
    {
        //invalid datetime
    }
