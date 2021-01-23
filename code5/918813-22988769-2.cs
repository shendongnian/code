      if (PlayerSelection > DealerCard) 
       { 
    Console.WriteLine ("You Win");
        }
      else if(DealerCard > PlayerSelection) 
      { 
    Console.WriteLine ("Dealer Wins");
      }
     else if (PlayerSelection == DealerCard)
      { 
    Console.WriteLine ("It is a draw");
      }
      else{Console.WriteLine("Something Went Wrong"}
