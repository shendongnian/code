    namespace DateIncrementTest
    {
        using System;
    
        class Program
        {
            static void Main(string[] args)
            {
                ProcessDates();
                Console.WriteLine("Press a key to Exit...");
                Console.ReadKey();
            }
    
            private static void ProcessDates()
            {
                DateTime startDate;
                DateTime.TryParse("1/1/2013", out startDate);
    
                DateTime endDate;
                DateTime.TryParse("1/7/2013", out endDate);
    
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    Console.WriteLine("Current Value for Date = {0}", date.ToShortDateString());
                }
            }
        }
    }
