    bool retry = false;
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
            case "1":
                Option1();
                break;
            case "2":
                Option2();
                break;
            case "3":
                Option3();
                break;
            case "4":
                break;
            default:
                Console.WriteLine("you didnt enter a valid input! try again.");
                continue = true;
                break;
        }
    } while(retry);
