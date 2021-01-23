    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RandomGeneratorPractice
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random random = new Random();
    
                int randomNumber1 = random.Next(1, 15);
                int randomNumber2 = random.Next(1, 15);
                int randomNumber3 = random.Next(1, 15);
    
                bool bln = true;
    
                while(bln)
                {
                if (randomNumber1 == randomNumber2)
                {
                    randomNumber2 = random.Next(1, 15);
    
                    bln = true;
                }
                else if (randomNumber2 == randomNumber3 || randomNumber1==randomNumber3)
                {
                    randomNumber3 = random.Next(1,15);
                    bln = true;
                }
                else if ((randomNumber1 != randomNumber2) && (randomNumber1 != randomNumber3) && (randomNumber2 != randomNumber3))
                {
                    bln = false;
                }
    
                }
    
                int dividend = randomNumber1 + randomNumber2 + randomNumber3;
                double divisor = 3;
                double quotient = (randomNumber1 + randomNumber2 + randomNumber3) / 3;
    
                Console.WriteLine("(" + randomNumber1 + "+" + randomNumber2 + "+" + randomNumber3 + ") / 3 = " + (dividend / divisor));
    
                if (dividend % divisor == 0)
                {
                    Console.WriteLine("You CAN divide by 3 evenly");
                }
                else
                {
                    Console.WriteLine("You CANNOT divide by 3 evenly");
                }
                
                Console.WriteLine("Press ENTER to exit...");
                Console.Read();
                
    
            }
        }
    }
