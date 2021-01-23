    void Main()
    {
        double amount = GetAmount();
    }
    double GetAmount()
    {
        double amount = 0;
        bool valid = GetAmount("How much would you like to transfer?", out amount);
    
        while (!valid) 
        {        
            bool valid = GetAmount("Please enter a valid amount to transfer?", out amount);
        }     
    }
    bool GetAmount(string message, out double amount)
    {
        Console.WriteLine(message);
        return double.TryParse(Console.ReadLine(), out amount)
            && amount > 0;
    }
