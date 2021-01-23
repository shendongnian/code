    public class Program
    {
        public static void Main(string[] args)
        {
            var items = Generate();
            
            var first = items.Take(8);
            var count = items.Count();
            var last = items.Skip(count - 4);
            Console.WriteLine("First items: {0}", string.Join(", ", first));
            Console.WriteLine("Last items: {0}", string.Join(", ", last));
            Console.WriteLine("Count: {0}", count);
        }
        
        private static IEnumerable<long> Generate()
        {
            return GenerateAll().TakeWhile(i => i >= 0);            
        }
        
        // generates an infinite sequence using GenerateNext
        private static IEnumerable<long> GenerateAll()
        {
            IEnumerable<long> items = new[] { 9L };
            
            while(true)
            {
                foreach(var item in items)
                {
                    yield return item;
                }
                items = GenerateNext(items);
            }
        }
        
        // generates the next items in the sequence.
        private static IEnumerable<long> GenerateNext(IEnumerable<long> xs)
        {
            foreach(var x in xs)
            {
                long x2 = 10 * x;
                yield return x2;
                yield return x2 + 9;
            }            
        }
    }
