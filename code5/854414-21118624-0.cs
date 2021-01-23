    Console.WriteLine("Press q to quit");
    
    bool quitFlag = false;
    while (!quitFlag )
    {
        Console.WriteLine("Please enter the date you wish to specify: (DD/MM/YYYY)");
        string userInput;
        userInput = Console.ReadLine();
        if (userInput == "q")
        {
            quitFlag = true;
        }
        else
        {
            DateTime calc = DateTime.Parse(userInput);
            TimeSpan days = DateTime.Now.Subtract(calc);
            Console.WriteLine(days.TotalDays);
            Console.ReadLine();
        }
    }
