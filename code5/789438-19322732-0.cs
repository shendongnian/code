    DateTime firstDate = ...;
    DateTime secondDate = ...;
    DateTime smallDate;
    DateTime bigDate;
    if (firstDate <= secondDate)
    {
        smallDate = firstDate;
        bigDate = secondDate;
    }
    else
    {
        smallDate = secondDate;
        bigDate = firstDate;
    }
    smallDate = smallDate.Date;
    bigDate = bigDate.Date;
    List<DateTime> dt = new List<DateTime>();
    while (smallDate <= bigDate)
    {
        dt.Add(smallDate);
        smallDate = smallDate.AddDays(1);
    }
