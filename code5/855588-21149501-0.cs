    class Program
    {
        static void Main(string[] args)
        {
            string one = "Hello";
            string two = one;
            two = "World";
            Console.WriteLine(one);
            StringBuilder sbone = new StringBuilder( "Hello");
            StringBuilder sbtwo = sbone;
            sbtwo.Clear().Append("world");
            Console.WriteLine(sbone);
            Console.ReadKey();
        }
    }
