using System;
namespace Assessment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Decalre Variables
            Random r = new Random();
            int PlayerNumber1 = r.Next(6, 25);
            int PlayerNumber2 = r.Next(6, 25);
            int DealerNumber1 = r.Next(6, 25);
            int DealerNumber2 = r.Next(6, 25);
            int PlayerTotal = (PlayerNumber1 + PlayerNumber2);
            int DealerTotal = (DealerNumber1 + DealerNumber2);
            Console.WriteLine("Welcome!");
            Console.ReadLine();
            Console.WriteLine("Your total is: " + PlayerTotal);
            Console.ReadLine();
            Console.WriteLine("Dealer total is: " + DealerTotal);
            Console.ReadLine();
            Console.WriteLine("Dealer total is: " + DealerTotal);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(DisplayResult(PlayerTotal, DealerTotal));
            Console.ReadLine();
        }
        private static string  DisplayResult(int playerTotal, int dealerTotal)
        {
            var result = "An unhandled exception has occured ";
            if (playerTotal > dealerTotal)
            {
                result = "You win!";
            }
            else if (playerTotal < dealerTotal)
            {
                result = "Dealer wins!";
            }
            else
            {
                result = "Draw!";
            }
            return result; 
        }
    }
}
 </pre> 
