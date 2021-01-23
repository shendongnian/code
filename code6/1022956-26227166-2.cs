    public Task<string> MakeTradeAsync()
    {
        NewTrade Test = new NewTrade();
    
        string reqid = await Test.Buy("JPM.NY", 100, 59.50);
    
        string orderNumber = await Test.GetOrderNumber(reqid);
    
        Console.WriteLine(orderNumber);
    
        return orderNumber;
    }
