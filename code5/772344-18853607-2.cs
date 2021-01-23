    var ranges = new List<int?>();
    ranges.Add(0); // today
    ranges.Add(7*2); // two weeks
    ranges.Add(DateTime.Today.Day); // within current month
    ranges.Add(DateTime.Today.DayOfYear); // within current year
    ranges.Sort();
