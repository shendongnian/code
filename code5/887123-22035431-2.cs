    do // Checks if the chosen name is also the right name
    {
        string test;
        Console.Write("Are you sure " + temp + " is the right name? (y/n)\n");
        test = Console.ReadLine(); // consider to use ReadKey
        Console.Write("\n");
        
        if (test.ToLower() == "n")
        {
            Console.Write("What is your name then?\n");
            temp = Console.ReadLine();
        }
        Console.Write("\n");
    } while (test.ToLower() != "y");
 
    return temp;
