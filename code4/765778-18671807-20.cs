    void Main()
    {
        double amount = GetAmount();
    }
    double GetAmount()
    {
        double amount = 0;
        bool valid = TryGetAmount("How much would you like to transfer?", out amount);
    
        while (!valid) 
        {        
            valid = TryGetAmount("Please enter a valid amount to transfer?", out amount);
        }
        return amount;
    }
    bool TryGetAmount(string message, out double amount)
    {
        Console.WriteLine(message);
        return double.TryParse(Console.ReadLine(), out amount)
            && amount > 0;
    }
