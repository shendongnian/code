    public class TestClass
    {
        private string _text;
        private void DoCompute(Action func)
        {
            func.Invoke();
        }
        private static void DoComputeStatic(Action func)
        {
            func.Invoke();
        }
        private static void StaticFunc()
        {
            Console.WriteLine("Static func");
        }
        private void NonstaticFunc()
        {
            Console.WriteLine(_text);
        }
        public void Run()
        {
            _text = "Nonstatic func";
            DoCompute(NonstaticFunc);
            DoComputeStatic(StaticFunc); //Can use static method - instance is ignored
        }
        public static void RunStatic()
        {
            DoComputeStatic(StaticFunc);
            //DoCompute(NonstaticFunc);  // Cannot use instance method - no instance
        }
        public void RunWithThread()
        {
            Thread thread = new Thread(() =>
            {
                _text = "Nonstatic func";
                DoCompute(NonstaticFunc);
            });
            thread.Start();
            thread.Join();
        }
    }
