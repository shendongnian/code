    int oddNumbersEntered = 0;
    int evenNumbersEntered = 0;
    // As soon as one of these variables equals '4', the loop will quit
    while (oddNumbersEntered < 4 && evenNumbersEntered < 4)
    {
        Console.Write("Please enter an integer: ");
        var input = Console.ReadLine();
        int value;
        bool success = int.TryParse(input, out value);
        if (success == false)
        {
            Console.WriteLine("The value entered is not a valid integer");
        }
        else if (value < 0)
        {
            Console.WriteLine("The value entered is negative");
        }
        else if (value == 0)
        {
            Console.WriteLine("The value entered is zero");
        }
        else if (value % 2 == 0)
        {
            evenNumbersEntered++; // This increments our even number counter by one
        }
        else
        {
            oddNumbersEntered++; // This increments our odd number counter by one
        }
    }
    Console.WriteLine("All done! You entered {0} even and {1} odd numbers",
        evenNumbersEntered, oddNumbersEntered);
    Console.Write("Press any key to exit...");
    Console.ReadKey();
