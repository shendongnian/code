    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace DateTimeFromString
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                List<string> dates = new List<string>()
                {
                    "2014-01",
                    "2013-04",
                    "2013-09"
                };
                // Split the string and instantiate new DateTime object to sort by later
                Func<string, DateTime> getDate = s => {
                    int[] dateParts = s
                        .Split(new char[] {'-'})
                        .Select(dp => int.Parse(dp))
                        .ToArray();
                    // Let's use the new DateTime(int year, int month, int day) constructor overload
                    // dateParts[0] is the year and dateParts[1] is the month;
                    // the magic number 1 below  is just a day to give to the DateTime constructor
                    return new DateTime(dateParts[0], dateParts[1], 1); 
                };
                List<DateTime> sortedDates = dates
                    .Select(d => getDate(d))
                    .OrderBy(d => d)
                    .ToList();
                Console.WriteLine(" Sorted Dates: ");
                sortedDates.ForEach(d => Console.WriteLine(d.Year.ToString() + " - " + d.Month.ToString()));
                // Let's get the minimum date and difference in months;
                DateTime minDate = sortedDates.Min();
                Dictionary<DateTime, int> datesWithMonthDifference = sortedDates
                    .ToDictionary(
                        sd => sd,
                        sd => ((sd.Year - minDate.Year) * 12 + sd.Month - minDate.Month)
                    );
                Console.WriteLine();
                Console.WriteLine("Sorted dates with month difference:");
                foreach (var key in datesWithMonthDifference.Keys)
                {
                    Console.WriteLine("{0} has difference of {1}", key, datesWithMonthDifference[key]);
                }
                Console.ReadKey();
            }
        }
    }
