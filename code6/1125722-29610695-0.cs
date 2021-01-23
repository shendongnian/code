    bool isPrime = true;
    for (int i = 3; i < number; i += 2)
    {
       if (number % i == 0)
       {
           isPrime = false;
       }
    }
    
    if (isPrime)
       Console.WriteLine("Number is prime!");
    else
       Console.WriteLine("Number is not prime.");
