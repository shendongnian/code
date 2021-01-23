    do
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Full File Listing.");
        Console.WriteLine("2. Filtered File Listing.");
        Console.WriteLine("3. FolderStatistics.");
        Console.WriteLine("4. Quit.");
        string mainMenuChoice = Console.ReadLine();
        switch(mainMenuChoice)
        {
            // same as above
            default:
                Console.WriteLine("You didn't enter a valid input! Try again.");
                continue; // goes back to beginning of the loop
        }
        break; // exits the loop
    } while(true);
