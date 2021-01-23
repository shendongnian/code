    class Program
    {
        static void Main(string[] args)
        {
            var foo = new FooBar();
            // new thread which tries to change the property foo.Var1
            FooBarChanger changer = new FooBarChanger(ref foo);
            var subThread = new Thread(changer.TryChange);
            subThread.IsBackground = true;
            subThread.Start();
            
            lock (foo)
            {
                foo.Var1 = 1;
                Console.WriteLine("main - lock: {0}", foo.Var1);
                Thread.Sleep(10000);
                Console.WriteLine("main - lock: updated value: {0}", foo.Var1);
            }
            Console.ReadLine();
        }
    }
    public class FooBarChanger
    {
        private FooBar _b;
        public FooBarChanger(ref FooBar b)
        {
            _b = b;
        }
        public void TryChange()
        {
            Thread.Sleep(1000);
            Console.WriteLine("subthread: changing value now!");
            _b.Var1 = 100;
            Console.WriteLine("subthread: {0}", _b.Var1);
        }
    }
    public class FooBar
    {
        public int Var1 { get; set; }
    }
