    class Program
    {
        static void Main(string[] args)
        {
            //Just looking at how the size of the INNER set affects time
            TimedTest(100000, 10000, 10);
            TimedTest(100000, 10000, 100);
            TimedTest(100000, 10000, 1000);
            TimedTest(100000, 10000, 10000);
            TimedTest(100000, 10000, 100000);
            TimedTest(100000, 10000, 1000000);
            Console.ReadLine();
        }
        static void TimedTest(int masterSize, int aSize, int bSize)
        {
            var masterList = Enumerable.Range(1, masterSize).ToArray();
            var aList = Enumerable.Range(1, aSize).ToArray();
            var bList = Enumerable.Range(1, bSize).ToArray();
            var w = new Stopwatch();
            //Subselect
            w.Restart();
            var x = (from m in masterList
                     join a in aList on m equals a
                     select new { B = bList.Where(b => b == m).SingleOrDefault() }).ToList();
            w.Stop();
            Console.WriteLine("Test for SUBSELECT master={0};a={1};b={2} took {3}ms and returned {4}", masterSize, aSize, bSize, w.ElapsedMilliseconds, x.Count);
            w.Restart();
            var y = (from m in masterList
                     join a in aList on m equals a
                     join b in bList on a equals b into bLeft
                     from bl in bLeft.DefaultIfEmpty()
                     select new { B = bl }).ToList();
            w.Stop();
            Debug.Assert(x.SequenceEqual(y));
            Console.WriteLine("Test for JOIN master={0};a={1};b={2} took {3}ms and returned {4}", masterSize, aSize, bSize, w.ElapsedMilliseconds, y.Count);
    
            //Join
    
        }
