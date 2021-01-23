    class Program
    {
        static void Main(string[] args)
        {
            var fooBar1 = new FooBar();
            Console.WriteLine(fooBar1.Baz);
            Console.WriteLine(fooBar1.Baz);
            var fooBar2 = new FooBar();
            Console.WriteLine(fooBar2.Baz);
            Console.WriteLine(fooBar2.Baz);
        }
    }
    public class FooBar
    {
        private static int counter;
        public int Baz => counter++;
    }
