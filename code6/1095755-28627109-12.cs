    using System;
    namespace ConsoleApplication1
    {
        public class A { public int j; }
        class Program
        {
            static void Main(string[] args)
            {
                A g = new A();
                Console.WriteLine(g.j);
            }
        }
    }
