    bool isPrime = true;
    
    //Stopping the loop once we know its not prime is better
    //Note that it won't even evaluate i < number if isPrime fails
    for (int i = 3; isPrime && i < number; i += 2)
    {
       if (number % i == 0)
       {
           isPrime = false;
        
           //Adding this line makes us more efficient
           //Some people don't like breaking flow like this though
           break; //We're done
       }
    }
    
    if (isPrime)
       Console.WriteLine("Number is prime!");
    else
       Console.WriteLine("Number is not prime.");
