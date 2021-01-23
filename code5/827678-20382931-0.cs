    DateTime startDate = new DateTime(2013, 12, 1); // or any other start date
    int numberOfDays = 5;
    var dates  = Enumerable.Range(0, numberOfDays)
                           .Select(i => startDate.AddDays(i))
                           .ToList();
