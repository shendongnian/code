    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, int>> ranges = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 24),
                new Tuple<int, int>(24, 48),
                new Tuple<int, int>(24, 72),
                new Tuple<int, int>(24, 120)
            };
            Func<Tuple<int, int>, string> getDaysFromHours = range =>
            {
                string formatted;
                if (range.Item2 > 24)
                {
                    formatted = string.Format(
                        "{0} - {1} days",
                        TimeSpan.FromHours(range.Item1).TotalDays,
                        TimeSpan.FromHours(range.Item2).TotalDays
                    );
                }
                else
                {
                    formatted = string.Format("{0} day",
                        TimeSpan.FromHours(range.Item2).TotalDays
                    );
                }
                return formatted;
            };
            ranges.ForEach(r =>
                Console.WriteLine(getDaysFromHours(r))
            );
            Console.ReadKey();
        }
    }
