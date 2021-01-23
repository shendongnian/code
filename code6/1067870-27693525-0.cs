    while (true)
    {
        if (userSelection == 1)
        {
            // CODES FOR FULL FILE LISTING"
        }
        else if (userSelection == 2)
        {
            // CODES FOR FILTERED FILE LISTING"
        }
        else if (userSelection == 3)
        {
            // CODES FOR DISPLAY FOLDER STATISTICS"
        }
        else if (userSelection == 4) //code that will be executed every time user select 4
        {
            // CODES TO QUIT"
        }
        else 
        {
             Console.WriteLine("ERROR MESSAGE HERE");
             break;
        }
        Console.WriteLine("Press Enter to Continue"); //waits for user to press enter
        Console.ReadKey(); //reads user keystroke
        Console.Clear(); //clears display information
        DisplayMenuOptions();
        userSelection = int.Parse(Console.ReadLine()); //reads and converts user selection
    }
