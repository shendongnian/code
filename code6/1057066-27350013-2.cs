    using System;
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                int[] NorthCliff = {15,14,13,12};
                for (int i = 12; i < 17; i++) {
                    Console.WriteLine(Array.IndexOf(NorthCliff, i));
                }
                Console.ReadLine();
            }
        }
    }
