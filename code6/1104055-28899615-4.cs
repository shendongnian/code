    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication2
    {
        public class SampleTime
        {
            public SampleTime(string timeLevel)
            {
                TimeLevel = timeLevel;
            }
            public readonly string TimeLevel;
        }
        public class Data
        {
            public int[] TimeRange = new int[2];
        }
        class Program
        {
            private static void Main(string[] args)
            {
                var initialResults = new []
                {
                    new SampleTime("0-5 Minutes"),
                    new SampleTime("4-5 Minutes"), // Should be selected below.
                    new SampleTime("1-8 Minutes"),
                    new SampleTime("4-6 Minutes"), // Should be selected below.
                    new SampleTime("4-7 Minutes"),
                    new SampleTime("5-6 Minutes"), // Should be selected below.
                    new SampleTime("20-30 Minutes")
                };
                // Find all ranges between 4 and 6 inclusive.
                Data data = new Data();
                data.TimeRange[0] = 4;
                data.TimeRange[1] = 6;
                // The output of this should be (as commented in the array initialisation above):
                //
                // 4-5 Minutes
                // 4-6 Minutes
                // 5-6 Minutes
                // Here's the significant code:
                var refinedResults = 
                (
                    from result in initialResults
                    let numbers = Regex.Matches(result.TimeLevel, @"\d+")
                    where ((int.Parse(numbers[0].Value) >= data.TimeRange[0]) && (int.Parse(numbers[1].Value) <= data.TimeRange[1]))
                    select result
                ).ToArray();
                foreach (var result in refinedResults)
                {
                    Console.WriteLine(result.TimeLevel);
                }
            }
        }
    }
