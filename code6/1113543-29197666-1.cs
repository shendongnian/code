    class Program
    {
        static void Main()
        {
            SomeClasss c = new SomeClasss();
            Console.WriteLine("Before: {0}", c.Name);
            c.MyProp = true;
            Console.WriteLine("After: {0}", c.Name);
            Console.ReadKey();
        }
    }
