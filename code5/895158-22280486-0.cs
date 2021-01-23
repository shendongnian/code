    //Server: 09-Mar-2014 11:00:00 AM:
    var serverTime = new DateTime(2014, 3, 9, 11, 00, 00);
    var serverZone = TimeZoneInfo.FindSystemTimeZoneById("US Mountain Standard Time");
    var localZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    var localTime = TimeZoneInfo.ConvertTime(serverTime, serverZone, localZone);
    // => 09-Mar-2014 11:30:00 PM
