    using System;
    
    namespace test {
        class Program {
            static void Main(string[] args) {
                String s = "0008";
                s = (Int32.Parse(s) + 1).ToString("D4"); Console.WriteLine(s);
                s = (Int32.Parse(s) + 1).ToString("D4"); Console.WriteLine(s);
                s = (Int32.Parse(s) + 1).ToString("D4"); Console.WriteLine(s);
                Console.ReadLine();
            }
        }
    }
