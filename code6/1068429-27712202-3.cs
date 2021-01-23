    class Program
    {
        static void Main(string[] args)
        {
            var dic1 = new Dictionary<int, string>;
            var dic2 = new Dictionary<int, string>;
    
            Random rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                int id = 0;
    
                do { id = rnd.Next(0, 1000000); } while (dic1.ContainsKey(id));
                dic1.Add(id, "hi");
    
                do { id = rnd.Next(0, 1000000); } while (dic2.ContainsKey(id));
                dic2.Add(id, "hello");
            }
    
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            var result1 = Intersect1(dic1, dic2);
            sw1.Stop();
    
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            var result2 = Intersect2(dic1, dic2);
            sw2.Stop();
    
            Console.WriteLine("Intersect1 elapsed {0} miliseconds", sw1.ElapsedMilliseconds);
            Console.WriteLine("Intersect2 elapsed {0} miliseconds", sw2.ElapsedMilliseconds);
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
    }
