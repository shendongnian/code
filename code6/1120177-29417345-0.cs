    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int integerSum = 0;
                int count = 0;
                while (true)
                {
                    Console.WriteLine("Please enter Integer {0} now.", (count + 1));
                    string rawInput = Console.ReadLine();
    
                    int integerInput;
                    bool isInteger = int.TryParse(rawInput, out integerInput);
    
                    if (isInteger == false)
                    {
                        Console.WriteLine("This is not a valid integer. Please enter a valid integer now:");
                    }
                    else
                    {
                        integerSum += integerInput;
                        count ++;
                    }
                    if (count >= 5)
                    {
                        break;
                    }
                }
                Console.WriteLine("sum = " + integerSum);
            }
        }
    }
