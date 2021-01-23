    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string toTest = "1.006,30";
    
                float number;
                if (float.TryParse(toTest, NumberStyles.AllowDecimalPoint | NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out number))
                    Console.WriteLine("Success: {0}", number);
                else
                    Console.WriteLine("Failure: strange number format");
    
                Console.WriteLine("Press any key to finish");
                Console.ReadKey();
            }
        }
    }
