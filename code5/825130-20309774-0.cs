    public class Program
    {
        private static void Main()
        {
            new Thread(() =>
                       {
                           Thread.Sleep(100);
                           GC.Collect();
                       }).Start();
            new SomeClass(10).Foo();
        }
    }
    public class SomeClass
    {
        public int I;
        public SomeClass(int input)
        {
            I = input;
            Console.WriteLine("I = {0}", I);
        }
        ~SomeClass()
        {
            Console.WriteLine("deleted");
        }
        public void Foo()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Foo");
        }
    }
