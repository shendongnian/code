    using System;
    
    namespace test {
        class Program {
            static void Main(string[] args) {
                int x = 8;
                x++; Console.WriteLine(x.ToString("D4"));
                x++; Console.WriteLine(x.ToString("D4"));
                x++; Console.WriteLine(x.ToString("D4"));
                Console.ReadLine();  // just because I'm in the IDE.
            }
        }
    }
