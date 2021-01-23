    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        static void Main()
        {
            string input = "13:12:34";
            
            DurationPattern pattern = 
                DurationPattern.CreateWithInvariantCulture("H:mm:ss");
            // TODO: Consider error handling. The ParseResult<T> returned by
            // pattern.Parse helps with that.
            Duration duration = pattern.Parse(input).Value;
            TimeSpan timeSpan = duration.ToTimeSpan();
            Console.WriteLine(timeSpan);
        }
    }
