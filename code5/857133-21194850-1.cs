    class Program
    {
        const int N = 10000;
        volatile private static int s_val;
        static void DoTest(IEnumerable<int> data, int[] selectors) {
            Stopwatch s;
            // Using .Single(predicate)
            s = Stopwatch.StartNew();
            foreach (var t in selectors) {
                s_val = data.Single(x => x == t);
            }
            s.Stop();
            Console.WriteLine("   {0} calls to Single(predicate) took {1} ms.",
                selectors.Length, s.ElapsedMilliseconds);
            // Using .Where(predicate).Single()
            s = Stopwatch.StartNew();
            foreach (int t in selectors) {
                s_val = data.Where(x => x == t).Single();
            }
            s.Stop();
            Console.WriteLine("   {0} calls to Where(predicate).Single() took {1} ms.",
                selectors.Length, s.ElapsedMilliseconds);
        }
        public static void Main(string[] args) {
            var R = new Random();
            var selectors = Enumerable.Range(0, N).Select(_ => R.Next(0, N)).ToArray();
            Console.WriteLine("Using IEnumerable<int>  (Enumerable.Range())");
            DoTest(Enumerable.Range(0, 10 * N), selectors);
            Console.WriteLine("Using int[]");
            DoTest(Enumerable.Range(0, 10*N).ToArray(), selectors);
            Console.WriteLine("Using List<int>");
            DoTest(Enumerable.Range(0, 10 * N).ToList(), selectors);
            Console.ReadKey();
        }
    }
