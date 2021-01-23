    while(true)
    {
        int attempts = 0;
        for(...)
        {
             if (guess < number)
             {
                 Console.WriteLine("Higher");
                 attempts++;
             }
             else if (guess > number)
             {
                 Console.WriteLine("Lower");
                 attempts++;                  
             }
        }
        Console.WriteLine("You win! {0} was the correct number! your attempts: {1}", number, attempts);
        Console.WriteLine("Would you like to try again ? (y / n)");
        if(Console.ReadLine().ToLower() != "y") break;
        
    }
