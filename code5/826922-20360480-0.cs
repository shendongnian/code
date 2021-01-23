    string rawDate = "PR242714031213";
    rawDate = rawDate.Substring(2);
    DateTime dt;
    if (!DateTime.TryParseExact(rawDate, 
                               "ssmmHHddMMyy", 
                               CultureInfo.InvariantCulture, 
                               DateTimeStyles.None, 
                               out dt))
    {
        //invalid date
    }
    string formattedDate = dt.ToString("ddMMyyyy");
