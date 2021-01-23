    using System;
    
    class Test
    {
        static void Main()
        {
            // Don't be fooled by the "standard" part - this is Central Time
            var zone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            var winter = new DateTime(2013, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var summer = new DateTime(2013, 6, 1, 0, 0, 0, DateTimeKind.Utc);
            Console.WriteLine(zone.IsDaylightSavingTime(winter)); // False
            Console.WriteLine(zone.IsDaylightSavingTime(summer)); // True
        }
    }
