    using System.IO;
    using System;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
           Random randomNumber = new Random();
    
           for (int j = 0; j < 1; j++)
           {
               StringBuilder largeRandomNumber = new StringBuilder();    
               for (int i = 0; i < 40; i++)
               { 
                   int value = randomNumber.Next(11111, 99999);
                   Console.WriteLine(value); 
                }
            }
        }
    }
