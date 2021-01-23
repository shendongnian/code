    var startDate = new DateTime(2013, 12, 1);
    var endDate = new DateTime(2013, 12, 5);
    var dates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                          .Select(x => startDate.AddDays(x))
                          .ToList();
