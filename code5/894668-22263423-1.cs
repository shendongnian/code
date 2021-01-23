    private static void DisplayResult(int playerTotal, int dealerTotal)
    {
       if(playerTotal > dealerTotal)
       {
           Console.WriteLine("You win!");
       }
       else if(playerTotal < dealerTotal)
       {
           Console.WriteLine("Dealer wins!");
       }
       else
       {
          Console.WriteLine("Draw!");
       } 
    }
