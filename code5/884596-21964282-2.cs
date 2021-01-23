    for (int i=0; i<=5; i++)
    {
       if (i == 5)
       {
            Console.WriteLine("Your Lose.  The answer is {0}", answer);
            break;
       }
        Console.Write("Enter Guess {0}:", i); 
        guess = Convert.ToInt32(Console.ReadLine());
        if (guess==answer)
        {
            Console.WriteLine("You Won!!    {0} is the correct number", answer);
            break;
        }
        else if (guess < answer)
        {
           Console.WriteLine("Guess is higher");
        }
        else if  (guess > answer)
        {
            Console.WriteLine("Guess is lower");
        }
    }
                    
