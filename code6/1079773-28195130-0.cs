    ﻿using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    
    namespace Pranas.WindowsTimeZoneToMomentJs
    {
        /// <summary>
        /// Tool to generates JavaScript that adds MomentJs timezone into moment.tz store.
        /// As per http://momentjs.com/timezone/docs/
        /// </summary>
        public static class TimeZoneToMomentConverter
        {
            private static readonly DateTimeOffset UnixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();
            private static readonly ConcurrentDictionary<Tuple<string, int, int, string>, string> Cache = new ConcurrentDictionary<Tuple<string, int, int, string>, string>();
    
            /// <summary>
            /// Generates JavaScript that adds MomentJs timezone into moment.tz store.
            /// It caches the result by TimeZoneInfo.Id
            /// </summary>
            /// <param name="tz">TimeZone</param>
            /// <param name="yearFrom">Minimum year</param>
            /// <param name="yearTo">Maximum year (inclusive)</param>
            /// <param name="overrideName">Name of the generated MomentJs Zone; TimeZoneInfo.Id by default</param>
            /// <returns>JavaScript</returns>
            public static string GenerateAddMomentZoneScript(TimeZoneInfo tz, int yearFrom, int yearTo, string overrideName = null)
            {
                var key = new Tuple<string, int, int, string>(tz.Id, yearFrom, yearTo, overrideName);
    
                return Cache.GetOrAdd(key, x =>
                {
                    var untils = EnumerateUntils(tz, yearFrom, yearTo).ToArray();
    
                    return string.Format(
    @"(function(){{
        var z = new moment.tz.Zone(); 
        z.name = {0}; 
        z.abbrs = {1}; 
        z.untils = {2}; 
        z.offsets = {3};
        moment.tz._zones[z.name.toLowerCase().replace(/\//g, '_')] = z;
    }})();",
                        Serializer.Serialize(overrideName ?? tz.Id),
                        Serializer.Serialize(untils.Select(u => "-")),
                        Serializer.Serialize(untils.Select(u => u.Item1)),
                        Serializer.Serialize(untils.Select(u => u.Item2)));
                });
            }
    
            private static IEnumerable<Tuple<long, int>> EnumerateUntils(TimeZoneInfo timeZone, int yearFrom, int yearTo)
            {
                // return until-offset pairs
                int maxStep = (int)TimeSpan.FromDays(7).TotalMinutes;
                Func<DateTimeOffset, int> offset = t => (int)TimeZoneInfo.ConvertTime(t, timeZone).Offset.TotalMinutes;
    
                var t1 = new DateTimeOffset(yearFrom, 1, 1, 0, 0, 0, TimeSpan.Zero);
    
                while (t1.Year <= yearTo)
                {
                    int step = maxStep;
    
                    var t2 = t1.AddMinutes(step);
                    while (offset(t1) != offset(t2) && step > 1)
                    {
                        step = step / 2;
                        t2 = t1.AddMinutes(step);
                    }
    
                    if (step == 1 && offset(t1) != offset(t2))
                    {
                        yield return new Tuple<long, int>((long)(t2 - UnixEpoch).TotalMilliseconds, -offset(t1));
                    }
                    t1 = t2;
                }
    
                yield return new Tuple<long, int>((long)(t1 - UnixEpoch).TotalMilliseconds, -offset(t1));
            }
        }
    }
