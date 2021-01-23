    class Program
    {
        static void Main(string[] args)
        {
            var instance = new ClassContainingTheMethod();
            var res1 = instance.MyFunction(1, 2, 3);
            var res2 = instance.MyFunction(new short[]{4, 5, 6});
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.ReadKey();
        }
    }
