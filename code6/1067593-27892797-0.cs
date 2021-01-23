    class Program
    {
        static void Main(string[] args)
        {
            var periods = new[]
            {
                new Period(new DateTime(2014, 01, 01), new DateTime(2014, 04, 30)),
                new Period(new DateTime(2014, 05, 01), new DateTime(2014, 07, 31)),
                new Period(new DateTime(2014, 08, 01), new DateTime(2014, 09, 30)),
            };
    
            // If you can extend the Period class you could use this query:
            var result1 = 
                periods
                .SelectMany(x => x)
                .Select(x => new SingleDate() { Date = x })
                .ToList();
    
            // If you cannot extend the Period class then this will do:
            var resul2 = 
            periods
            .Select(x => new[] 
            {
                new SingleDate() { Date = x.PeriodStart }, 
                new SingleDate() { Date = x.PeriodEnd } 
            })
            .SelectMany(x => x).ToList();
        }
    }
    
