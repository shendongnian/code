    var today = DateTime.Today;
    var range = new Range<DateTime>(today.AddDays(-7), today);
    DateTime date = new DateTime(2013, 9, 25);
    if (range.Contains(date))
       // say good
