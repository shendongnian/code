    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(Environment.TickCount);
            var cases = 1000;
            List<int> a = new List<int>(cases);
            List<int> b = new List<int>(cases);
            for (int c = 0; c < cases; c++)
            {
                a.Add(random.Next(9999));
                b.Add(random.Next(9999));
            }
    
            var times = 100;
            var usesCount = 1;
    
            Console.WriteLine("{0} times", times);
            for (int u = 0; u < 4; u++)
            {
                Console.WriteLine();
                Console.WriteLine("{0} uses per result", usesCount);
                TestMethod(a, b, "Tigrou-Where", Where, times, usesCount);
                TestMethod(a, b, "Tigrou-Intersect", Intersect, times, usesCount);
                TestMethod(a, b, "Tigrou-Join", Join, times, usesCount);
                TestMethod(a, b, "Servy-GroupJoin", GroupJoin, times, usesCount);
                TestMethod(a, b, "Servy-HashSet", HashSet, times, usesCount);
                TestMethod(a, b, "Servy-JoinDisctinct", JoinDistinct, times, usesCount);
                TestMethod(a, b, "JoseH-TheOldFor", TheOldFor, times, usesCount);
                usesCount *= 2;
            }
    
            Console.ReadLine();
        }
    
        private static void TestMethod(List<int> a, List<int> b, string name, Func<List<int>, List<int>, IEnumerable<int>> method, int times, int usesCount)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            for (int t = 0; t < times; t++)
            {
                // Process
                var result = method(a, b);
                // Count
                for (int u = 0; u < usesCount; u++)
                {
                    count = 0;
                    foreach (var item in result)
                    {
                        count++;
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine("{0,-20}: count={1,4}, {2,8:N1}ms", 
                name, count, stopwatch.ElapsedMilliseconds);
        }
    
        private static IEnumerable<int> Where(List<int> a, List<int> b)
        {
            return a.Where(x => b.Contains(x));
        }
    
        private static IEnumerable<int> Intersect(List<int> a, List<int> b)
        {
            return a.Intersect(b); 
        }
    
        private static IEnumerable<int> Join(List<int> a, List<int> b)
        {
            return a.Join(b, x => x, y => y, (x, y) => x);
        }
    
        private static IEnumerable<int> GroupJoin(List<int> a, List<int> b)
        {
            return from n in a
                   join k in b
                   on n equals k into matches
                   where matches.Any()
                   select n;
        }
    
        private static IEnumerable<int> HashSet(List<int> a, List<int> b)
        {
            var set = new HashSet<int>(b);
            return a.Where(n => set.Contains(n));
        }
    
        private static IEnumerable<int> JoinDistinct(List<int> a, List<int> b)
        {
            return a.Join(b.Distinct(), x => x, y => y, (x, y) => x);
        }
    
        private static IEnumerable<int> TheOldFor(List<int> a, List<int> b)
        {
            var result = new List<int>();
            int countA = a.Count;
            var setB = new HashSet<int>(b);
            for (int loopA = 0; loopA < countA; loopA++)
            {
                var itemA = a[loopA];
                if (setB.Contains(itemA))
                    result.Add(itemA);
            }
            return result;
        }
    }
