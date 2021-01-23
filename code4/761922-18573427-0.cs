    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please input some numbers. Use SPACE as separator");
                string line = Console.ReadLine();
                var userInput = new List<int>();
    
                foreach (string entry in line.Split(' '))
                {
                    int number;
                    if (!string.IsNullOrEmpty(entry) && int.TryParse(entry, out number))
                        userInput.Add(number);
                }
    
                const int lowest = 0;
    
                Console.WriteLine("The lowest number above {0} is: {1}", lowest, userInput.Where(n => n > lowest).Min());
    
                Console.WriteLine("Press any key to finish.");
                Console.ReadKey();
            }
        }
    }
