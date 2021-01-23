    bool userIsDone = false;
    Console.Write("\nWould you like to process...");
    while (!userIsDone)
    {
        string userInput = Console.ReadLine();
        // ...
        if (userInput == "Y")
        {
            // process another set here
            Console.WriteLine("\nWould you like to process...");
        }
        else if (userInput == "N")
        {
            // exit your program
        }
        else
        {
            Console.WriteLine("That input is invalid.");
        }
    }
