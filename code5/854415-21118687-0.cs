    Console.WriteLine("Please enter the date you wish to specify: (DD/MM/YYYY)");
    string userInput;
    userInput = Console.ReadLine();
    while (userInput != "0")
    {
        DateTime calc = DateTime.Parse(userInput);
        TimeSpan days = DateTime.Now.Subtract(calc);
        Console.WriteLine(days.TotalDays);
        Console.WriteLine("Add another date");
        userInput = Console.ReadLine();
    }
