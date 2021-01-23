    int totalDays = endTime.Subtract(startTime).TotalDays;
    List<DateTime> dates = new List<DateTime>(totalDays + 1); // using this constructor will make filling in the list more performant
    dates.Add(startTime); // since you mentionned start and end should be included
    for (var i = 1; i < totalDays; i++)
    {
        dates.Add(startTime.AddDays(i));
    }
    dates.Add(endTime);
