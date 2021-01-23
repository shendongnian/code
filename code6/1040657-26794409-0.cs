    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Baseline.");
            Test1();
            Console.WriteLine("Modified.");
            Test2();
        }
        static void Test1()
        {
            IEnumerable<int> num = new[] { 10, 11, 12, 13, 14, 15, 16 };
            IEnumerable<int> div = new[] { 2, 3, 5 };
            var lazy = Enumerable.Empty<int>();
            var x = div.GetEnumerator();
            while (x.MoveNext())
            {
                int d1 = x.Current;
                Console.WriteLine("d1 = " + d1);
                lazy = lazy.Concat(num.Where(s => {bool result = s % d1 == 0; Console.WriteLine("s = " + s + ", d1 = " + d1); return result;}));
                Console.WriteLine("lazy has " + lazy.Count());
            }
            Console.WriteLine("Evaluating lazy.Distinct().Count()");        
            int count = lazy.Distinct().Count();
            Console.WriteLine("{0}", count);
        }
        static void Test2()
        {
            IEnumerable<int> num = new[] { 10, 11, 12, 13, 14, 15, 16 };
            IEnumerable<int> div = new[] { 2, 3, 5 };
            var lazy = Enumerable.Empty<int>();
            var x = div.GetEnumerator();
            int d1;
            while (x.MoveNext())
            {
                d1 = x.Current;
                Console.WriteLine("d1 = " + d1); 
                lazy = lazy.Concat(num.Where(s => {bool result = s % d1 == 0; Console.WriteLine("s = " + s + ", d1 = " + d1); return result;}));
                Console.WriteLine("lazy has " + lazy.Count());
            }
            Console.WriteLine("Evaluating lazy.Distinct().Count()");
            int count = lazy.Distinct().Count();
            Console.WriteLine("{0}", count);
        }
    }
