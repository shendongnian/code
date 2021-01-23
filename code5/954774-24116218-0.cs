    class Program
    {
        static void Main(string[] args)
        {
            var task1 = new TaskFactory().StartNew(Method1);
            var task2 = task1.ContinueWith(delegate { Method2(); });
            var task3 = task2.ContinueWith(delegate { Method1(); });
        }
        private static void Method1()
        {
            
        }
        private static void Method2()
        {
        }
