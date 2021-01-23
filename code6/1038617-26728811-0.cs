    var groupByAdmsn = listOfStudent.
    GroupBy(x => x.Admission < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0).AddDays(1) &&
     x.Admission >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0))
    .Select(x => x)
    .ToList();
