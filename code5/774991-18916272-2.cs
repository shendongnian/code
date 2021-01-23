    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            var zone = DateTimeZoneProviders.Tzdb["America/Chicago"];
            var winter = Instant.FromUtc(2013, 1, 1, 0, 0);
            var summer = Instant.FromUtc(2013, 6, 1, 0, 0);
            
            Console.WriteLine(zone.GetZoneInterval(winter).Savings); // +00
            Console.WriteLine(zone.GetZoneInterval(summer).Savings); // +01
            Console.WriteLine(zone.GetZoneInterval(winter).Savings != Offset.Zero); // False
            Console.WriteLine(zone.GetZoneInterval(summer).Savings != Offset.Zero); // True
        }
    }
