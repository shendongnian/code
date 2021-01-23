    class Program
    {
        volatile private static int s_val;
        public static void Main(string[] args) {
            const int N = 10000;
            Stopwatch s;
            // Generate some data to test against
            var data = Enumerable.Range(0, 100000).ToArray();
            var R = new Random();
            var selectors = Enumerable.Range(0, N).Select(_ => R.Next(0, data.Length)).ToArray();
            // Try Single(predicate)
            s = Stopwatch.StartNew();
            foreach (int t in selectors) {
                s_val = data.Single(x => x == t);
            }
            s.Stop();
            Console.WriteLine("1) {0} calls to Single(predicate) took {1} ms.",
                selectors.Length, s.ElapsedMilliseconds);
            // Try Where(predicate).Single()
            s = Stopwatch.StartNew();
            foreach (int t in selectors) {
                s_val = data.Where(x => x == t).Single();
            }
            s.Stop();
            Console.WriteLine("1) {0} calls to Where(predicate).Single() took {1} ms.",
                selectors.Length, s.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
