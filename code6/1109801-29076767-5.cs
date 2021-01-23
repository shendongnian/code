    using System;
    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            private static void Main()
            {
                string filename = @"d:\test\test.xml"; // Substitute your own filename here.
                // Open XML file and get a collection of each "Name" element.            
                var doc = XDocument.Load(filename);
                var jobs = doc.Descendants("Name");
                // Extract the date, job number, and total time from each "Name" element.:
                var data = jobs.Select(job => new
                {
                    Date = (DateTime)job.Element("Date"),
                    Number = (string)job.Element("JobNum"),
                    Duration = TimeSpan.FromTicks((long)job.Element("TotalTime"))
                });
                // Group the jobs by date, and order the groups by job name:
                var result = 
                    data.GroupBy(job => job.Date).OrderBy(g => g.Key)
                    .Select(g => new
                    {
                        Date = g.Key, 
                        Jobs = g.OrderBy(item => item.Number)
                    });
                // Print out the results:
                foreach (var jobsOnDate in result)
                {
                    Console.WriteLine("{0:d}", jobsOnDate.Date);
                    foreach (var job in jobsOnDate.Jobs)
                        Console.WriteLine("    {0}  {1:hh\\:mm}", job.Number, job.Duration);
                }
            }
        }
    }
