    // parse the input
    string input = "21Fr";
    // assuming week number is always 2 characters. e.g.: 01, 02, ..., 21, ...
    int weeks = int.Parse(input.Substring(0, 2));
    // assuming abbreviated day names like this
    string[] abbrDayNames = { "Su", "Mo", "Tu", "We","Th", "Fr", "Sa" };
    int dayOfWeekValue = Array.IndexOf(abbrDayNames, input.Substring(2));
    DayOfWeek dayOfWeek = (DayOfWeek)dayOfWeekValue;
    // now let's build the DateTime
    // start from first day of year, 6:00 AM
    DateTime parsed = new DateTime(DateTime.Now.Year, 1 ,1, 6, 0, 0);
    // add first part, weeks
    parsed = parsed.AddDays((weeks - 1) * 7);
    // reset to first day of week
    parsed = parsed.AddDays(-(int)parsed.DayOfWeek);
    // then add the second part, day of week
    parsed = parsed.AddDays((int)dayOfWeek);
