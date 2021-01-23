    class Program
    {
        static void Main(string[] args)
        {
            TestClass tceOn = new TestClass();
            Stopwatch s = Stopwatch.StartNew();
            s.Checkpoint("Before sync on");
            tceOn.Execute();
            s.Checkpoint("After sync on");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }
    }
    class TestClass
    {
        public Foo Execute()
        {
            Thread.Sleep(3000);
            return new Foo();
        }
    }
    class Foo { }
