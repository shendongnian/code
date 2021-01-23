    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            var local = new LocalDateTime(2014, 3, 30, 2, 30, 0);
            var zone = DateTimeZoneProviders.Tzdb["Europe/Paris"];
            
            var zoned = local.InZoneLeniently(zone);
            Console.WriteLine(zoned);  // 2014-03-30T03:00:00 Europe/Paris (+02)
        }
    }
