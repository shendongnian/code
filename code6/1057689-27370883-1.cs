    private void button1_Click(object sender, EventArgs e)
    {
        string client;
        string date;
        string telNumber;
    
        const decimal TaxRate = 0.43M;
    
        uint Quantity, Amount, Total;
    
        decimal TotalOrder, TaxAmount, SalesTotal, TotalQuantity;
        decimal UnitPrice, AmountTended, Difference, TotalAmount;
    
    
        Console.SetCursorPosition(10, 5);
        Console.ForegroundColor = ConsoleColor.Yellow;
        client = Console.ReadLine();
    
        Console.SetCursorPosition(10, 7);
        Console.ForegroundColor = ConsoleColor.Yellow;
        client = Console.ReadLine();
    
        Console.SetCursorPosition(58, 5);
        Console.ForegroundColor = ConsoleColor.Yellow;
        date = Console.ReadLine();
    
        Console.SetCursorPosition(67, 7);
        Console.ForegroundColor = ConsoleColor.Yellow;
        telNumber = Console.ReadLine();
    
        //TotalQuantity
        TotalQuantity = PromptDecimal(2);
    
        //Item Description
    
        Console.SetCursorPosition(18, 12);
        Console.ForegroundColor = ConsoleColor.Yellow;
        telNumber = Console.ReadLine();
    
        //Unit Price    
        UnitPrice = PromptDecimal(47);
    
        //Computations
    
        //TotalAmount
        **TotalAmount = TotalQuantity*UnitPrice;
        **
    
        Console.SetCursorPosition(65, 12);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("P ");
        Console.WriteLine(TotalQuantity*UnitPrice);
        Console.ReadLine();
    }
