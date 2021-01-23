    using System;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static bool showErrorMessage = false;
            static void calc(int number)
            {
                if (number==1)
                {
                    Console.WriteLine("USD");
                }
                else if (number == 2)
                {
                    Console.WriteLine("EURO");
                }
                else
                {
                    getNumber();
                }
                Console.ReadLine();
            }
    
            static void getNumber()
            {
                if (showErrorMessage)
                {
                    Console.WriteLine("You Entered Invalid Number ,Only 1 and 2 Valid, Please Try Again :");
                }
                int number = 0;
                if (Int32.TryParse(Console.ReadLine().ToString(),out number))
                {
                    calc(number);
                }
                else
                {
                    showErrorMessage = true;
                    getNumber();
                   
                }
            }
            static void Main(string[] args)
            {
                getNumber();
            }
        }
    }
