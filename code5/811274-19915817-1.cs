    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication3 {
        class Program {
            static void Main(string[] args) {
                List<byte> A = new List<byte>{80,81,90,90,90,100,85,86,86,79,95,95,95};
                byte last = 0;
                int count = 0;
                foreach (byte b in A) {
                    if (b == last) count++;
                    else count = 0;
                    if (count >=2) Console.WriteLine("Instructor has given " + b + " " +     (count+1) + " times in a row");
                    last = b;
                }
            }
        }
    }
