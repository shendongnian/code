    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (var z = 0; true; z++)
                {
                    Console.WriteLine(z);
                    Thread.Sleep(200);
                }
            }
        }
    }
