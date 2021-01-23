    var possibleDates = allDates.Where(x => x < inputDate);
    if (possibleDates.Any())
    {
        var closestDate = possibleDates.Max();
    }
