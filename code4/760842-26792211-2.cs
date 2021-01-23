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
                //Variables declared to hold and test conversion
                //floats used to avoid int calculation errors
                float originalFarenheit;
                float centigrade;
                float returnFarenheit;
    
                Console.Write("Enter Temperature (Farenheit): ");      //take temp to be converted
                originalFarenheit = float.Parse(Console.ReadLine());   //hold as float var
                centigrade = ((originalFarenheit - 32) / 9) * 5;       //Convert to centrigrade
                returnFarenheit = ((centigrade / 5) * 9) + 32;         //test conversion by reversing
    
                Console.WriteLine("Centigrade = :" + centigrade);              //Display result
                Console.WriteLine("Return Farenheit = :" + returnFarenheit);   //Test result
    
                Console.ReadKey();
            }
        }
    }
