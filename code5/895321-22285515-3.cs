    class Program
    {
        static void Main(string[] args)
        {
            MethodScheduler ms = new MethodScheduler();
            ms.Init();
            ms.MethodCompleted += MethodCompletedHandler;
            MethodInvokeState mtA = new MethodInvokeState(new Func<bool>(SomeMethodA));
            MethodInvokeState mtB = new MethodInvokeState(new Func<bool>(SomeMethodB));
            ms.RegisterMethod(mtA);
            ms.RegisterMethod(mtB);
            Console.WriteLine(" * SENDER: Waiting for completion (SomeMethodA) ...");
            bool result = mtA.WaitForCompletion();
            Console.WriteLine(" * SENDER: SomeMethodA completed: " + result);
            Console.WriteLine(" * SENDER: Waiting for completion (SomeMethodB) ...");
            result = mtB.WaitForCompletion();
            Console.WriteLine(" * SENDER: SomeMethodB completed: " + result);
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
            ms.Stop();
        }
        public static void MethodCompletedHandler(Object sender, MethodCompletedEventArgs e)
        {
            Console.WriteLine(" * HANDLER: Method '{0}' completed with: {1} " , e.Method.Name, e.Result.ToString());
        }
        public static bool SomeMethodA()
        {
            Console.WriteLine(" * SomeMethodA: will succeed in 5 seconds!");
            Thread.Sleep(5000);
            return true;
        }
        public static bool SomeMethodB()
        {
            Console.WriteLine(" * SomeMethodB: will fail in 3 seconds!");
            Thread.Sleep(3000);
            return false;
        }
    }
