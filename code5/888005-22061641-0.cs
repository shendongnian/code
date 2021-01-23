    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        static void Main()
        {
            string s = "2014-02-02T24:00:00";
            var pattern = LocalDateTimePattern.CreateWithInvariantCulture
                 ("yyyy-MM-dd'T'HH:mm:ss");
            var dt = pattern.Parse(s).Value;
            Console.WriteLine(pattern.Format(dt)); // 2014-02-03T00:00:00
        }
    }
