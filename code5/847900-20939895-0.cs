    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int[] bins = { 0, 21, 29, 0, 50 };
            int[] testResults = { 0, 0, 0, 0, 0 };
            var cumulated = bins.CumulativeSum().Select((i, x) => new { i, x });
            for (int count=0; count < 100000; count++)
            {
                var randomNumber = random.Next(0, 100);
                var matchIndex = cumulated.First(j => j.i > randomNumber).x;
                testResults[matchIndex]++;
            }
            for (int i=0; i < testResults.Length; i++)
            {
                Console.WriteLine("Matches in bin " + i + ": " + (double)testResults[i] /1000);
            }
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
