    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class TempConvert
        {
            static void Main(string[] args)
            {
                float originalFarenheit;
                float centigrade;
                float returnFarenheit;
    
                Console.Write("Enter Temperature (Farenheit): ");
                originalFarenheit = float.Parse(Console.ReadLine());
                centigrade = ((originalFarenheit - 32) / 9) * 5;
                returnFarenheit = ((centigrade / 5) * 9) + 32;
    
                Console.WriteLine("Centigrade = :" + centigrade);
                Console.WriteLine("Return Farenheit = :" + returnFarenheit);
    
                Console.ReadKey();
            }
        }
    }
