    var total = 0;  // This will hold the sum of all entries
    var result = 0;  // This will hold the current entry
    // This condition will loop until the user enters -1
    while (result != -1)
    {
        // Write the prompt out to the console window
        Console.Write("Enter the amount (-1 to stop): ");
        // Capture the user input (which is a string)
        var input = Console.ReadLine();
        // Try to parse the input into an integer (if TryParse succeeds, 
        // then 'result' will contain the integer they entered)
        if (int.TryParse(input, out result))
        {
            // If the user didn't enter -1, add the result to the total
            if (result != -1) total += result;
        }
        else
        {
            // If we get in here, then TryParse failed, so let the user know.
            Console.WriteLine("{0} is not a valid amount.", input);
        }
    }
    // If we get here, it means the user entered -1 and we exited the while loop
    Console.WriteLine("The total of your entries is: {0}", total);
