    using System;
    using NodaTime;
    using NodaTime.TimeZones;
    
    class Test
    {
        static void Main()
        {
            var local = new LocalDateTime(2014, 3, 30, 2, 30, 0);
            var zone = DateTimeZoneProviders.Tzdb["Europe/Paris"];
     
            var resolver = Resolvers.CreateMappingResolver(
                  ambiguousTimeResolver: Resolvers.ReturnEarlier,
                  skippedTimeResolver: Resolvers.ReturnEndOfIntervalBefore);
            var zoned = local.InZone(zone, resolver);
            Console.WriteLine(zoned); // 2014-03-30T01:59:59 Europe/Paris (+01)
        }
    }
