    class Foo
    {
        public int Value;
        public Foo Next;
        public Foo(int value) { this.Value = value; Console.WriteLine("Created " + this.Value); }
        ~Foo() { Console.WriteLine("Finalized " + this.Value); }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var foo = new Foo(0);
            for (int value = 1; value < 50; ++value)
            {
                foo.Next = new Foo(value);
                foo = foo.Next;
                if (value % 10 == 0)
                {
                    Console.WriteLine("Collecting...");
                    GC.Collect();
                    Thread.Sleep(10);
                }
            }
            Console.WriteLine("Exiting");
        }
    }
