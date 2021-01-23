    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            var us = new CultureInfo("en-US");
            var uk = new CultureInfo("en-GB");
            string text = "07/06/2013 11:22:12 am";
            
            // This one fails, as there's no appropriate time format
            Console.WriteLine(GuessPattern(text, us));
            // This one prints dd/MM/yyyy HH:mm:ss
            Console.WriteLine(GuessPattern(text, uk));
        }
        
        static string GuessPattern(string text, CultureInfo culture)
        {
            foreach (var pattern in GetDateTimePatterns(culture))
            {
                DateTime ignored;
                if (DateTime.TryParseExact(text, pattern, culture,
                                           DateTimeStyles.None, out ignored))
                {
                    return pattern;
                }
            }
            return null;
        }
        
        static IList<string> GetDateTimePatterns(CultureInfo culture)
        {
            var info = culture.DateTimeFormat;
            return new string[]
            {
                info.FullDateTimePattern,
                info.LongDatePattern,
                info.LongTimePattern,
                info.ShortDatePattern,
                info.ShortTimePattern,
                info.MonthDayPattern,
                info.ShortDatePattern + " " + info.LongTimePattern,
                info.ShortDatePattern + " " + info.ShortTimePattern,
                info.YearMonthPattern
                // Consider the sortable pattern, ISO-8601 etc
            };        
        }
    } 
