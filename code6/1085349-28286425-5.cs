    using System;
    using ClassLibrary1;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Class1 instance = new Class1();
                Console.WriteLine(instance.x);
                Console.WriteLine(instance.y);
                Console.WriteLine(instance.width);
                Console.WriteLine(instance.height);
            }
        }
    }
