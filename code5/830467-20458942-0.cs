    private void message(int choice, string result)
    {
       string self;
       switch(choice)
       {
         case 1: self = "Rock"; break;
         case 2: self = "Paper"; break;
         case 3: self = "Scissor"; break;
       }
       switch(result)
       {
         case "Draw":
           MessageBox.Show(String.Format("It is a draw. Both chose {0}", self));
           break;
         case "Win":
           string beats;
           switch(choice)
           {
             case 1: beats = "Scissor"; break;
             case 2: beats = "Rock"; break;
             case 3: beats = "Paper"; break;
           }
           MessageBox.Show(String.Format("Congratulations! {0} beats {1}", self, beats));
           break;
         case "Lose":
           string loses;
           switch(choice)
           {
             case 1: loses = "Paper"; break;
             case 2: loses = "Scissor"; break;
             case 3: loses = "Rock"; break;
           }
           MessageBox.Show(String.Format("You lose. {1} beats {0}", self, loses));
           break;
           break;
       }
    }
