    public class FooBar
    {
        public int Var1 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new FooBar();
            foo.Var1 = 0;
            Thread t = new Thread(new ParameterizedThreadStart(NewThread));
            t.Start(foo);
            lock (foo)
            {
                foo.Var1 = 1;
                Thread.Sleep(10000);
                foo.Var1 = 2;
            }
        }
        public static void NewThread(object foo)
        {
            Thread.Sleep(5000);
            Console.WriteLine((foo as FooBar).Var1);
        }
        
    }
