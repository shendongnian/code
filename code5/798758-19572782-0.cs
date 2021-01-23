    for (int i = num; i >= 1; i--)
    {
        factorial = factorial * i;
        Console.Write(i.ToString() + " x ");
    }
    
    Console.WriteLine("factorial of " + number_str.ToString() + " is " + factorial);    
