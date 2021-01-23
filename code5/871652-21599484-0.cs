    var eventTime = new DateTimeOffset(2014, 2, 6, 10, 0, 0, 0, TimeSpan.FromHours(3));
    var serverTime = new DateTimeOffset(2014, 2, 6, 10, 0, 0, 0, TimeSpan.FromHours(1));
    var otherTime = new DateTimeOffset(2014, 2, 6, 10, 0, 0, 0, TimeSpan.FromHours(-1));
    Console.WriteLine("\tLocalTime\t\t\tUtcTime\t\tInThePast");
    Console.WriteLine("Server\t{0}\t{1}",serverTime, serverTime.UtcDateTime);
    Console.WriteLine("Event\t{0}\t{1}\t{2}", eventTime, eventTime.UtcDateTime, eventTime < serverTime);
    Console.WriteLine("Other\t{0}\t{1}\t{2}", otherTime, otherTime.UtcDateTime, otherTime < serverTime);
