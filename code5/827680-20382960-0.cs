    DateTime startDate = new DateTime(2013, 12, 1);
    DateTime endDate = new DateTime(2013, 12, 5);
    List<DateTime> dates =
                          Enumerable.Range(0, ((endDate - startDate).Days) + 1)
                          .Select(n => startDate.AddDays(n))
                          .ToList();
