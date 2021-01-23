    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        sealed class EqualityComparer: IEqualityComparer<string[]>
        {
            public bool Equals(string[] x, string[] y)
            {
                return x.SequenceEqual(y);
            }
            public int GetHashCode(string[] obj)
            {
                if (obj == null)
                    return 0;
                int hash = 17;
                foreach (string s in obj)
                    hash = hash*23 + ((s == null) ? 0 : s.GetHashCode());
                return hash;
            }
        }
    
        class Program
        {
            private void run()
            {
                var list = new List<string[]>
                {
                    strings(1, 10), 
                    strings(2, 10), 
                    strings(3, 10), 
                    strings(2, 10), 
                    strings(4, 10)
                };
                dump(list);
                Console.WriteLine();
            
                var result = list.Distinct(new EqualityComparer());
                dump(result);
            }
            static void dump(IEnumerable<string[]> list)
            {
                foreach (var array in list)
                    Console.WriteLine(string.Join(",", array));
            }
            static string[] strings(int start, int count)
            {
                return Enumerable.Range(start, count)
                    .Select(element => element.ToString())
                    .ToArray();
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
