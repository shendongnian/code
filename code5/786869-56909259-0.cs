    using System;
    using NodaTime;
    
    namespace qwerty
    {
        class Program
        {
            static void Main(string[] args)
            {
                var convertedInUTC = ConvertToUtcFromCustomTimeZone("America/Chihuahua", DateTime.Now);
                Console.WriteLine(convertedInUTC);
            }
    
            private static DateTime ConvertToUtcFromCustomTimeZone(string timezone, DateTime datetime) 
            {
                DateTimeZone zone = DateTimeZoneProviders.Tzdb[timezone];
                var localtime = LocalDateTime.FromDateTime(datetime);
                var zonedtime = localtime.InZoneLeniently(zone);
                return zonedtime.ToInstant().InZone(zone).ToDateTimeUtc();
            }
        }
    }
