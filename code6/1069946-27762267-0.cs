    string userAnswer = "yes";
    // while is usually more readable than do-while
    while (userAnswer == "yes")
    {
        Console.WriteLine("Please input a number for it to be counted!");
        int number;
        // Ask for new input until the user inputs a valid number
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid number, try again");
        }
        if (number < 1000)
        {
            // Print from 0 to number, jumping in 2's
            for (int i = 0; i <= number; i += 2)
                Console.WriteLine(i + " ");
        }
        else
        {
            Console.WriteLine("APPLICATION ERROR: NUMBER MUST BE BELOW OR AT 1000 TO PREVENT OVERFLOW!");
            continue; // Jump back to the start of this loop
        }
        Console.WriteLine("Continue? (Yes / No)");
        userAnswer = Console.ReadLine().ToLower();
        // Ask for new input until the user inputs "Yes" or "No"
        while (userAnswer != "yes" && userAnswer != "no")
        {
            Console.WriteLine("Invalid input. Continue? (Yes / No)");
            userAnswer = Console.ReadLine().ToLower();
        }
    }
