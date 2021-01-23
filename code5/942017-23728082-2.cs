    /*
     * Program.cs
     */
    
    using System;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length > 0)
                {
                    Console.WriteLine(File.ReadAllText(args[0]));
                }
    
                // Pause for 5 seconds to see the double-clicked file's output on the console.
                Thread.Sleep(5000);
            }
        }
    }
