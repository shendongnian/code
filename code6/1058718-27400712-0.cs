    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        static void Main()
        {
            ExtractFirstNumber("Event: 1 - Some event");
            ExtractFirstNumber("Event: 12 -");
            ExtractFirstNumber("Event: 123");
            ExtractFirstNumber("Event: 12 - Some event 3");
            ExtractFirstNumber("Event without a number");
        }
    
        private static readonly Regex regex = new Regex(@"\d+");
        static void ExtractFirstNumber(string text)
        {
            var match = regex.Match(text);
            Console.WriteLine(match.Success ? match.Value : "No match");
        }
    }
