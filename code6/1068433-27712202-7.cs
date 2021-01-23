    class Program
    {
        static void Main(string[] args)
        {
            var dic1 = new Dictionary<int, string>();
            var dic2 = new Dictionary<int, string>();
    
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 100000; i++)
            {
                int id = 0;
    
                do { id = rnd.Next(0, 1000000); } while (dic1.ContainsKey(id));
                dic1.Add(id, "hi");
    
                do { id = rnd.Next(0, 1000000); } while (dic2.ContainsKey(id));
                dic2.Add(id, "hello");
            }
    
            List<List<string>> results = new List<List<string>>();
    
            using (new AutoStopwatch(true)) { results.Add(Intersect1(dic1, dic2)); }
            Console.WriteLine("Intersect1 elapsed in {0}ms (HashSet)", AutoStopwatch.Stopwatch.ElapsedMilliseconds);
    
            using (new AutoStopwatch(true)) { results.Add(Intersect2(dic1, dic2)); }
            Console.WriteLine("Intersect2 elapsed in {0}ms (GroupBy)", AutoStopwatch.Stopwatch.ElapsedMilliseconds);
    
            using (new AutoStopwatch(true)) { results.Add(Intersect3(dic1, dic2)); }
            Console.WriteLine("Intersect3 elapsed in {0}ms (Keys.Intersect)", AutoStopwatch.Stopwatch.ElapsedMilliseconds);
    
            using (new AutoStopwatch(true)) { results.Add(Intersect4(dic1, dic2)); }
            Console.WriteLine("Intersect4 elapsed in {0}ms (Where1)", AutoStopwatch.Stopwatch.ElapsedMilliseconds);
    
            using (new AutoStopwatch(true)) { results.Add(Intersect5(dic1, dic2)); }
            Console.WriteLine("Intersect5 elapsed in {0}ms (Where2)", AutoStopwatch.Stopwatch.ElapsedMilliseconds);
    
            Console.ReadKey();
        }
    
        static List<string> Intersect1(Dictionary<int, string> dic1, Dictionary<int, string> dic2)
        {
            HashSet<int> commonKeys = new HashSet<int>(dic1.Keys);
            commonKeys.IntersectWith(dic2.Keys);
            var result =
                dic1
                .Where(x => commonKeys.Contains(x.Key))
                .Concat(dic2.Where(x => commonKeys.Contains(x.Key)))
                .Select(x => x.Value)
                .ToList();
            return result;
        }
    
        static List<string> Intersect2(Dictionary<int, string> dic1, Dictionary<int, string> dic2)
        {
            var result = dic1.Concat(dic2)
                        .GroupBy(x => x.Key)
                        .Where(g => g.Count() > 1)
                        .SelectMany(g => g.Select(x => x.Value))
                        .ToList();
            return result;
        }
    
        static List<string> Intersect3(Dictionary<int, string> dic1, Dictionary<int, string> dic2)
        {
            var result =
                dic1
                .Keys
                .Intersect(dic2.Keys)
                .SelectMany(key => new[] { dic1[key], dic2[key] })
                .ToList();
            return result;
        }
    
        static List<string> Intersect4(Dictionary<int, string> dic1, Dictionary<int, string> dic2)
        {
            var result =
                dic1.
                Where(pair => dic2.ContainsKey(pair.Key))
                .SelectMany(pair => new[] { dic2[pair.Key], pair.Value }).ToList();
            return result;
        }
    
        static List<string> Intersect5(Dictionary<int, string> dic1, Dictionary<int, string> dic2)
        {
            var result =
                dic1
                .Keys
                .Where(dic2.ContainsKey).SelectMany(k => new[] { dic1[k], dic2[k] })
                .ToList();
            return result;
        }
    }
    
    class AutoStopwatch : IDisposable
    {
        public static readonly Stopwatch Stopwatch = new Stopwatch();
    
        public AutoStopwatch(bool start)
        {
            Stopwatch.Reset();
            if (start) Stopwatch.Start();
        }
        public void Dispose()
        {
            Stopwatch.Stop();
        }
    }
