    namespace ConsoleApplication1
    {
        using System;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                var AS = new[] { "red", "red", "Grey", "Grey", "blue" };
                var zippedList = AS.Zip(Enumerable.Range(0, AS.Length), (s, i) => new { s, i });
    
                var finalResult =
                    from a in zippedList
                    group a by a.s into g
                    select new { key = g.Key, result = new { list = g.Select(o => o.i).ToList(), count = g.Count() } };
                foreach (var item in finalResult)
                {
                    Console.WriteLine(item.key);
                    Console.WriteLine(item.result.count);
                    Console.WriteLine(item.result.list);
                }
                Console.ReadLine();
            }
        }
    }
