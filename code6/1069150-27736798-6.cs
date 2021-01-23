    private static void GenericTester()
    {
        // This will flag that the user wants to quit
        bool quit = false;
        while(!quit)
        {
            // Get input from user
            int userInput = GetIntFromUser("Please input a number to be counted: ");
            int number = 0;
            // Write out the numbers
            if (userInput <= 1000)
            {
                while (number <= userInput)
                {
                    Console.Write(number + " ");
                    number += 2;
                }
            }
            else
            {
                Console.WriteLine("APPLICATION ERROR: NUMBER MUST BE BELOW " +
                    "OR AT 1000 TO PREVENT OVERFLOW!");
            }
            // See if they want to continue
            while (true)
            {
                // Get user input
                Console.Write("Do you want to continue - Yes or No: ");
                string choice = Console.ReadLine();
                // If they said 'No', set flag to quit and break out of this loop
                if (choice.Equals("No", StringComparison.OrdinalIgnoreCase))
                {
                    quit = true;
                    break;
                }
                // If they said 'Yes', just break out of this loop
                if (choice.Equals("Yes", StringComparison.OrdinalIgnoreCase)) break;
                // Otherwise, display an error message and let the loop continue
                Console.WriteLine("ERROR INVALID INPUT: Only input Yes or No!");
            }
        }
    }
