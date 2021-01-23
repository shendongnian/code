    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int[] roulette = { 0, 21, 29, 0, 50 };
            var cumulated = roulette.CumulativeSum().Select((i, index) => new { i, index });
            var randomNumber = random.Next(0, 100);
            var matchIndex = cumulated.First(j => j.i > randomNumber).index;
            Console.WriteLine(roulette[matchIndex]);
        }
    }
    public static class SumExtensions
    {
        public static IEnumerable<int> CumulativeSum(this IEnumerable<int> sequence)
        {
            int sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
                yield return sum;
            }
        }
    }
