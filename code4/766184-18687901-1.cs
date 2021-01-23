    class Program
    {
        static void Main(string[] args)
        {
            AbstractFoo foo = new LoggedFoo(new DefaultFoo());
            
            Console.WriteLine(foo.X());
        }
    }
