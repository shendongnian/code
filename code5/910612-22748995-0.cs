    public void Play()
            {
               HiLow hi = new HiLow();
               int number = hi.Number;
               int guess;
       int attempts=0;
               for (guess = PromptForInt("\nEnter your guess! "); guess != number; guess = PromptForInt("\nEnter your guess! "))
               {
                   if (guess < number)
                   {
                       Console.WriteLine("Higher");
                   }
                   else if (guess > number)
                   {
                       Console.WriteLine("Lower");                  
                   }
    attempts++;
               }
               Console.WriteLine("You win! {0} was the correct number!", number);
            }
