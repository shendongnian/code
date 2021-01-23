    using System;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Guid g1 = Guid.Parse("c47632a3-274b-44d0-93df-f9626a033a6f");
            Guid g2 = Guid.Parse("c47632a3-274b-43d0-93df-f9626a033a6f");
            Console.WriteLine(g1);
            Console.WriteLine(g2);
            Console.WriteLine(GetResult(g1,g2));
            Console.ReadLine();
        }
        public static string GetResult(Guid Guid1, Guid Guid2)
        {
            return Guid1.CompareTo(Guid2) < 0 ? Guid1.ToString() + Guid2.ToString() : Guid2.ToString() + Guid1.ToString();
        }
    }
    }
