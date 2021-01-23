     class Program
        {
            static void Main(string[] args)
            {
    
                string StartDate = "2007-03-24";
                string EndDate = "2009-06-26";
    
                System.DateTime firstDate = DateTime.ParseExact(StartDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                System.DateTime secondDate = DateTime.ParseExact(EndDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
    
                System.TimeSpan diff = secondDate.Subtract(firstDate);
                var totalDays = (diff).TotalDays;
                var totalYears = Math.Truncate(totalDays / 365);
                var totalMonths = Math.Truncate((totalDays % 365) / 30);
                var remainingDays = Math.Truncate((totalDays % 365) % 30);
                Console.WriteLine("Estimated duration is {0} year(s), {1} month(s) and {2} day(s)", totalYears, totalMonths, remainingDays);
                Console.ReadLine();
    
            }
    
        }
