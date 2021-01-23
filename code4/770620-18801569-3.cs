    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List<KeyValuePair<string, int>>() { 
                    new KeyValuePair<string, int>("A", 1),
                    new KeyValuePair<string, int>("B", 2),
                    new KeyValuePair<string, int>("C", 3),
                    new KeyValuePair<string, int>("D", 4),
                    new KeyValuePair<string, int>("E", 5),
                    new KeyValuePair<string, int>("F", 6),
                };
                int input = 12;
                var alternatives = list.SubSets().Where(x => x.Sum(y => y.Value) == input);
                foreach (var res in alternatives)
                {
                    Console.WriteLine(String.Join(",", res.Select(x => x.Key)));
                }
                Console.WriteLine("END");
                Console.ReadLine();
            }
        }
        public static class Extenions
        {
            public static IEnumerable<IEnumerable<T>> SubSets<T>(this IEnumerable<T> enumerable)
            {
                List<T> list = enumerable.ToList();
                ulong upper = (ulong)1 << list.Count;
                for (ulong i = 0; i < upper; i++)
                {
                    List<T> l = new List<T>(list.Count);
                    for (int j = 0; j < sizeof(ulong) * 8; j++)
                    {
                        if (((ulong)1 << j) >= upper) break;
                        if (((i >> j) & 1) == 1)
                        {
                            l.Add(list[j]);
                        }
                    }
                    yield return l;
                }
            }
        }
    }
