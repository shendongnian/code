        static string Method1(string a)
        {
            return a;
        }
        static void Method2(string a, string b)
        {
            Console.WriteLine(a + b);
        }
        static string Method3(string a, string b, int x)
        {
            return String.Format("a:{0} b:{1} x:{2}", a, b, x);
        }
        static int Method4(int x)
        {
            return x;
        }
        static void Main(string[] args)
        {
            var methods = new Dictionary<string, Func<int, string, string, string, string>>()
            {
                { "method1", (x, a, b, c) => Method1(a) },
                { "method2", (x, a, b, c) => { Method2(a, b); return ""; } },
                { "method3", (x, a, b, c) => Method3(a, b, x) },
                { "method4", (x, a, b, c) => Method4(x).ToString() },
            };
            foreach (var key in methods.Keys)
                Console.WriteLine(key + ": " + methods[key](1, "a", "b", "c"));
            Console.ReadKey();
        }
