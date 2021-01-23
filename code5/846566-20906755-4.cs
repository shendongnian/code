    static class Program
    {
        static void Main(string[] args)
        {
            var outputCount = 10;
            var hours = new[] { 8, 12, 17 };
            //var hours = new[] { 12, 17 };
            //var hours = new[] { 6, 8, 10, 12, 16, 18, 22};
            var d = new DateTime(2014, 01, 02, 15, 00, 00);
            var d1 = new DateTime(d.Year, d.Month, d.Day);
            var dates = Enumerable.Range(0, 2 + (outputCount / hours.Length))
                .Select(i => d1.AddDays(i))
                .Aggregate<DateTime, List<DateTime>>(new List<DateTime>(), (a, b) =>
                {
                    for (int i = 0; i < hours.Length; i++)
                    {
                        a.Add(b.AddHours(hours[i]));
                    }
                    return a;
                }
            ).Where(date => date > d).Take(outputCount).ToList();
            foreach (var date in dates)
            {
                Console.WriteLine(date);
                Console.WriteLine("-------------------------");
            }
            Console.Read();
        }
    }
