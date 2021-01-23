    var l = new List<DateTime> {
        new DateTime(2014, 11, 11, 15, 0, 0),   // 15:00:00
        new DateTime(2014, 11, 11, 16, 0, 0),   // 16:00:00
        new DateTime(2014, 11, 11, 17, 0, 0),   // 17:00:00
        new DateTime(2014, 11, 11, 17, 20, 0),  // 17:20:00
        new DateTime(2014, 11, 11, 18, 15, 0),  // 18:15:00
        new DateTime(2014, 11, 11, 19, 0, 0),   // 19:00:00
        new DateTime(2014, 11, 11, 22, 0, 0),   // 22:00:00
        new DateTime(2014, 11, 11, 23, 45, 0),  // 23:45:00
        new DateTime(2014, 11, 11, 23, 50, 00), // 23:50:00
        new DateTime(2014, 12, 11, 00, 50, 00), // 00:50:00
        new DateTime(2014, 11, 12, 1, 0, 0),    // 01:00:00
        new DateTime(2014, 11, 12, 10, 0, 0),   // 10:00:00
    };
    var time = new TimeSpan(18, 0, 0); // <- Set the target time here
    var offsetBefore = new TimeSpan(1, 0, 0, 0).TotalMilliseconds - time.TotalMilliseconds;
    var offsetAfter = time.TotalMilliseconds * -1;
    var closestBefore =
        l.Aggregate(
            (current, next) =>
                next.AddMilliseconds(offsetBefore).TimeOfDay.TotalMilliseconds > current.AddMilliseconds(offsetBefore).TimeOfDay.TotalMilliseconds
                    ? next
                    : current);
    var closestAfter =
        l.Aggregate(
            (current, next) =>
                next.AddMilliseconds(offsetAfter).TimeOfDay.TotalMilliseconds < current.AddMilliseconds(offsetAfter).TimeOfDay.TotalMilliseconds
                    ? next
                    : current);
    Console.WriteLine("{0} is the closest date/time before {1}.", closestBefore, time);
    Console.WriteLine("{0} is the closest date/time after {1}.", closestAfter, time);
    Console.WriteLine("00:00:00 - {0} {1} \n", closestBefore, closestAfter);
    // OUTPUTS:
    //   11/11/2014 17:20:00 is the closest date/time before 18:00:00.
    //   11/11/2014 18:15:00 is the closest date/time after 18:00:00.
    //   00:00:00 - 11/11/2014 17:20:00 11/11/2014 18:15:00    
