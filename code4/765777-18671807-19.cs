    double amount;
    Console.WriteLine("How much would you like to transfer?");
    bool valid = double.TryParse(Console.ReadLine(), out amount)
        && amount > 0;
    while (!valid) 
    {        
        Console.WriteLine("Please enter a valid amount to transfer?");
        valid = double.TryParse(Console.ReadLine(), out amount)
            && amount > 0;
    } 
