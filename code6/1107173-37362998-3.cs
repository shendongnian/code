        struct method_parameters
        {
            public string a;
            public string b;
            public int x;
        }
        static string Method1(method_parameters parameters)
        {
            return parameters.a;
        }
        static void Method2(method_parameters parameters)
        {
            Console.WriteLine(parameters.a + parameters.b);
        }
        static string Method3(method_parameters parameters)
        {
            return String.Format("a:{0} b:{1} x:{2}",
                parameters.a, parameters.b, parameters.x);
        }
        static int Method4(method_parameters parameters)
        {
            return parameters.x;
        }
        static void Main(string[] args)
        {
            method_parameters parameters = new method_parameters()
            {
                a = "a",
                b = "b",
                x = 1
            };
            var methods = new Dictionary<string, Func<method_parameters, string>>()
            {
                { "method1", Method1 },
                { "method2", (param) => { Method2(param); return ""; } },
                { "method3", Method3 },
                { "method4", (param) => Method4(param).ToString() },
            };
            foreach (var key in methods.Keys)
                Console.WriteLine(key + ": " + methods[key](parameters));
            Console.ReadKey();
        }
