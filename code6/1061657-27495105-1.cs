    using System;
    using System.Threading;
    namespace Repeat
    {
        class Program
        {
            static int GetIntFromConsole(string label)
            {
                int result;
                string input;
                do
                {
                    Console.Write("{0}: ", label);
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out result));
                return result;
            }
            static void Main(string[] args)
            {
                int result;
                result = GetIntFromConsole("Kod");
                while (result != 1946)
                {
                    Console.WriteLine("Locked");
                    Thread.Sleep(4000); // 4 seconds = 4000 milliseconds
                    result = GetIntFromConsole("Kod");
                } 
                Console.WriteLine("Unlocked");
            }
        }
    }
