    public static bool SameDate(DateTimeOffset first, DateTimeOffset second)
    {
        bool returnValue = false;
        DateTime firstAdjusted = first.ToUniversalTime().Date;
        DateTime secondAdjusted = second.ToUniversalTime().Date;
        // calculate the total diference between the dates   
        int diff = first.Date.CompareTo(firstAdjusted) - second.Date.CompareTo(secondAdjusted);
        // the firstAdjusted date is corected for the difference in BOTH dates.
        firstAdjusted = firstAdjusted.AddDays(diff);
        if (DateTime.Compare(firstAdjusted, secondAdjusted) == 0)
            returnValue = true;
        return returnValue;
    }
