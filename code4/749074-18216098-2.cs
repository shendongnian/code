    string hours, rate, total;
    Console.Write("Enter consultation time in hours");
    hours = Console.ReadLine();
    rate = ;
    decimal hourInput = 0;
    if(!decimal.TryParse(hours, out hourInput)
    {
        Console.Write("Thats not a number!");
    }
    else
    {
        total = Convert.ToString(hourInput * Convert.ToDecimal(rate));
        Console.WriteLine("Fee is " + total);
    }
