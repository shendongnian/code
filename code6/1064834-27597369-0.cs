    public delegate void TestScript();
    class Program
    {
        private static Evaluator _evaluator;
        private static void Main(string[] args)
        {
            _evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
            var test=Create("System.Console.WriteLine(\"Test\"); System.Console.ReadKey();");
            var helloWorld = Create("System.Console.WriteLine(\"Hello from Script!\"); System.Console.ReadKey();");
            test();
            helloWorld();
        }
        public static TestScript Create(string script)
        {
            // Feed it some code
            return ()=>_evaluator.Evaluate(script);
        }
    }
