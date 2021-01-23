    public class Program
    {
        public static void Main(string[] args)
        {
            var foo = new Foo();
            Monitor.Enter(foo);
            foo = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }
    }
    internal class Foo
    {
        ~Foo()
        {
            Console.WriteLine("~Foo");
        }
    }
