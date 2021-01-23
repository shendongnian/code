    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        static void Main()
        {
            Duration duration = Duration.FromMinutes(6000);
            var pattern = DurationPattern.CreateWithInvariantCulture("H:mm");
            string text = pattern.Format(duration);
            Console.WriteLine(text); // 0:31
        }
    }
