    var l = new List<DateTime> {
        new DateTime(2014, 11, 11, 22, 0, 0),   // 22:00:00
        new DateTime(2014, 11, 11, 23, 45, 0),  // 23:45:00
        new DateTime(2014, 11, 11, 23, 50, 00), // 23:50:00
        new DateTime(2014, 12, 11, 00, 50, 00), // 00:50:00
        new DateTime(2014, 11, 12, 1, 0, 0),    // 01:00:00
        new DateTime(2014, 11, 12, 10, 0, 0),   // 10:00:00
    };
    var closestBeforeMidnight =
        l.Aggregate(
            (current, next) =>
                next.TimeOfDay.TotalMilliseconds > current.TimeOfDay.TotalMilliseconds
                    ? next
                    : current);
    var closestAfterMidnight =
        l.Aggregate(
            (current, next) =>
                next.TimeOfDay.TotalMilliseconds < current.TimeOfDay.TotalMilliseconds
                    ? next
                    : current);
    Console.WriteLine("{0} is the closest date/time before midnight.", closestBeforeMidnight);
    Console.WriteLine("{0} is the closest date/time after midnight.", closestAfterMidnight);
    Console.WriteLine("00:00:00 - {0} {1} \n", closestBeforeMidnight, closestAfterMidnight);
    // OUTPUTS:
    //   11/11/2014 23:50:00 is the closest date/time before midnight.
    //   11/12/2014 00:50:00 is the closest date/time after midnight.
    //   00:00:00 - 11/11/2014 23:50:00 11/12/2014 00:50:00
