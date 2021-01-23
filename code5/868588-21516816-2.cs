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
                    return new DateTime(dateParts[0], dateParts[1], 1); // the magic number 1 here is just a day to give to the DateTime constructor
                };
                List<DateTime> sortedDates = dates
                    .Select(d => getDate(d))
                    .OrderBy(d => d)
                    .ToList();
                sortedDates.ForEach(d => 
                    Console.WriteLine(
                        d.Year.ToString() + 
                        " - " + 
                        d.Month.ToString()
                    )
                );
                Console.ReadKey();
            }
        }
    }
