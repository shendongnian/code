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
    
                int min = int.MaxValue;
                
                if (!string.IsNullOrEmpty(line))
                {
                    foreach (string entry in line.Split(' '))
                    {
                        int number;
                        if (!string.IsNullOrEmpty(entry) && int.TryParse(entry, out number))
                            userInput.Add(number);
                    }
                }
    
                const int lowest = 0;
                foreach(int number in userInput)
                {
                    if (number > lowest)
                        min = Math.Min(number, min);
                }
    
                Console.WriteLine("The lowest number above {0} is: {1}", lowest, min);
    
                Console.WriteLine("Press any key to finish.");
                Console.ReadKey();
            }
        }
    }
