    using System;
    namespace DumpVersion
    {
        class Program
        {
            static int EntryPoint(string argument)
            {
                Console.Out.WriteLine(argument);
                Console.Out.WriteLine(Environment.Version);
                Console.In.ReadLine();
                return 0;
            }
            static void Main()
            {
                EntryPoint("Main");
            }
        }
    }
