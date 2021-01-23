    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        sealed class JobData
        {
            public JobData(DateTime date, string name, double ticks)
            {
                _date = date;
                _name = name;
                _ticks = ticks;
            }
            public DateTime Date
            {
                get
                {
                    return _date;
                }
            }
            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public double Ticks
            {
                get
                {
                    return _ticks;
                }
            }
            private readonly DateTime _date;
            private readonly string   _name;
            private readonly double   _ticks;
        }
        class Program
        {
            private static void Main()
            {
                var date1 = new DateTime(2015, 04, 11);
                var date2 = new DateTime(2015, 04, 12);
                var date3 = new DateTime(2015, 04, 13);      
                // Note that these items are NOT in the same order as the required output.
                // This demonstrates that the "OrderBy" is correct in the Linq.
                IEnumerable<JobData> data = new []
                {
                    new JobData(date3, "27255", 4.25),
                    new JobData(date1, "27111", 8.00),
                    new JobData(date3, "26820", 1.33),
                    new JobData(date2, "26820", 8.00),
                    new JobData(date3, "01det", 4.33),
                    new JobData(date1, "26820", 2.25)
                };
                // Group the jobs by date, and order the groups by job name:
                var result = 
                    data.GroupBy(job => job.Date).OrderBy(g => g.Key)
                    .Select(g => new
                    {
                        Date = g.Key, 
                        Jobs = g.OrderBy(item => item.Name)
                    });
                foreach (var jobsOnDate in result)
                {
                    Console.WriteLine("{0:d}", jobsOnDate.Date);
                    foreach (var job in jobsOnDate.Jobs)
                    {
                        Console.WriteLine("    {0}  {1:f2}", job.Name, job.Ticks);                    
                    }
                }
            }
        }
    }
