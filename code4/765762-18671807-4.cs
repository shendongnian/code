    bool valid = false;
    double amount;
    while (!valid) 
    {
        Console.WriteLine("How much would you like to transfer?");
        
        valid = double.TryParse(Console.ReadLine(), out amount)
            && amount > 0;
    } 
