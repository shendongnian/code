    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            string text = "2013-09-17T14:55:00.355-08:00";
            DateTimeOffset dto = DateTimeOffset.ParseExact(text,
                "yyyy-MM-dd'T'HH:mm:ss.fffzzz",
                CultureInfo.InvariantCulture);
            Console.WriteLine(dto);
        }
    } 
