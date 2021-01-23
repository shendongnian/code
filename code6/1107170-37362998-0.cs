        static string Method1(string a)
        {
            return "";
        }
        static void Method2(string a, string b)
        {
        }
        static string Method3(string a, string b, int x)
        {
            return "";
        }
        static void Main(string[] args)
        {
            var _methods = new Dictionary<string, Func<int, string, string, string, string>>()
            {
                { "method1", (x, a, b, c) => Method1(a) },
                { "method2", (x, a, b, c) => { Method2(a, b); return ""; } },
                { "method3", (x, a, b, c) => Method3(a, b, x) }
            };
            Console.ReadKey();
        }
