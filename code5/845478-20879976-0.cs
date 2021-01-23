    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        static void Main()
        {
            string text = "2007-04-05T24:00";
            var pattern = LocalDateTimePattern.CreateWithInvariantCulture
                 ("yyyy-MM-dd'T'HH:mm");
            var dateTime = pattern.Parse(text).Value;
            Console.WriteLine(pattern.Format(dateTime)); // 2007-04-06T00:00
        }
    }
