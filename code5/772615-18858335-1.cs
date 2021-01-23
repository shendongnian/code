    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        static void Main()        
        {
            string text = "2013-09-17T14:55:00.355-08:00";
            // Use GeneralIsoPattern just to get a default culture/template value
            OffsetDateTime odt = OffsetDateTimePattern.GeneralIsoPattern
                .WithPatternText("yyyy-MM-dd'T'HH:mm:ss.fffo<+HH:mm>")
                .Parse(text)
                .Value;
            Console.WriteLine(odt);
        }
    } 
