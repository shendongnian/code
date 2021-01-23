    string hours;
    decimal numericHours, rate, total;
    
    Console.Write("Enter consultation time in hours");
    hours = Console.ReadLine();
    if (!Decimal.TryParse(hours, out numericHours))
    {
        Console.WriteLine(String.Format("{0} doesn't appear to be a valid number of hours. Please enter a numeric value.", hours));
    }
    else
    {
        rate = 35.6;
        total = numericHours * rate;
        Console.WriteLine("Fee is " + total);
    }
