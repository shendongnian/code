    using System;
    using System.Threading;
    
    namespace TestMutex
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var mutex = new Mutex(true, "MyUniqueMutexName"))
                {
                    // Do something
                    for (int i = 0; i < 10000; i++)
                        Console.Write(".");
                    Console.WriteLine();
                    Console.WriteLine("Press enter...");
                    Console.ReadLine();
                    mutex.ReleaseMutex();
                }
                for (int i = 0; i < 10000; i++)
                    Console.Write(".");
                Console.WriteLine();
                Console.WriteLine("Press enter...");
                Console.ReadLine();
    
            }
        }
    }
