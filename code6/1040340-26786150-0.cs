    class Program
    {
        public class X
        {
            public void foo()
            {
                Console.WriteLine("x");
            }
            public virtual void bar()
            {
                Console.WriteLine("x");
            }
        }
        public class Y : X
        {
            public new void foo()
            {
                Console.WriteLine("y");
            }
            public override void bar()
            {
                Console.WriteLine("y");
            }
        }
        static void Main(string[] args)
        {
            var y = new Y();
            var x = y as X;
            var z = x as dynamic;
            x.foo();
            y.foo();
            z.foo();
            x.bar();
            y.bar();
            z.bar();
            Console.Read();
        }
    }
