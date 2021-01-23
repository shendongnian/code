    static class Program
    {
        static void Main(string[] args)
        {
            DateTime d = new DateTime(2014, 01, 02, 8, 00, 00);
            var d1 = new DateTime(d.Year, d.Month, d.Day);
            var dates = Enumerable.Range(0, 1 + (40 / 3)).Select(i => d1.AddDays(i))
                .Aggregate<DateTime, List<DateTime>>(new List<DateTime>(), (a, b) =>
                {
                    a.Add(b.AddHours(8));
                    a.Add(b.AddHours(12));
                    a.Add(b.AddHours(17));
                    return a;
                }
            ).Where(date => date > d).Take(40).ToList();
            foreach (var date in dates)
            {
                Console.WriteLine(date);
                Console.WriteLine("-------------------------");
            }
            Console.Read();
        }
    }
