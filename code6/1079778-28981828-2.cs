    using System;
    using System.Linq;
    
    using NodaTime;
    using Newtonsoft.Json;
    
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateMomentJsZoneData("Europe/London", 2010, 2020));
        }
        
        static string GenerateMomentJsZoneData(string tzdbId, int fromYear, int toYear)
        {
            var intervals = DateTimeZoneProviders
                .Tzdb[tzdbId]
                .GetZoneIntervals(Instant.FromUtc(fromYear, 1, 1, 0, 0),
                                  Instant.FromUtc(toYear + 1, 1, 1, 0, 0))
                .ToList();
            
            var abbrs = intervals.Select(interval => interval.Name);
            var untils = intervals.Select(interval => interval.End.Ticks / NodaConstants.TicksPerMillisecond);
            var offsets = intervals.Select(interval => -interval.WallOffset.Ticks / NodaConstants.TicksPerMinute);
            var result = new { name = tzdbId, abbrs, untils, offsets };
            return JsonConvert.SerializeObject(result);
        }
    }
