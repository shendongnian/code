    static bool AnotherConversion()
    {
        var prompt = "\nWould you like to make an another conversion? \n\n(Enter (Y) to make another conversion or (N) to return to the Main Menu):";
        Console.WriteLine(prompt);
    
        while (true)
        {
            var userInput = Console.ReadLine();
    
            if (String.Compare("Y", userInput, StringComparison.Ordinal)
            {
                return true;
            }
            else if (String.Compare("N", userInput, StringComparison.Ordinal)
            {
                return false;
            }
            else
            {
                // Invlalid input, re-prompt
                Console.WriteLine("Invalid Input, please enter or (Y) or (N)!");
                Console.WriteLine(prompt);
            }
        }
    }
