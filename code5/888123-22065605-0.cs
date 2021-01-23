    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            var dto = DateTimeOffset.ParseExact
                ("Sun Feb 23 2014 00:00:00 GMT+0550",
                 "ddd MMM d yyyy HH:mm:ss 'GMT'zzz",
                 CultureInfo.InvariantCulture);
            Console.WriteLine(dto); // 23/02/2014 00:00:00 +05:50
        }
    }
