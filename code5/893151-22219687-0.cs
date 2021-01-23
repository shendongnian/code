    var existingDates = queryResult.Select(x => x.Date).ToArray();
    // if queryResult is known to be sorted replace with .First() and .Last().
    var startDate = existingDates.Minimum();
    var endDate = existingDates.Maximum();
    var dateCount = (endDate - startDate).Days;
    var missingDates = Enumerable.Range(0, dateCount)
                                 .Select(i => startDate.AddDays(i))
                                 .Where(d => !existingDates.Contains(d));
    var allData = queryResult.Concat(missingDates.Select(d => new { Date = d, Count = 0}));
