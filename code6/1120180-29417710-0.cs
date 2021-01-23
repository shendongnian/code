    private static int SumFiveInts()
    {
        Console.WriteLine("This program accepts 5 integers from the user and returns their sum.\nIf an invalid integer is entered, the program notifies the user and asks for correct input.");
        int sum = 0;
        for (int i = 0; i < 5; i++)
        {
            sum += GetIntegerFromConsole(i);
        }
        return sum;
    }
    public static int GetIntegerFromConsole(int attempt)
    {
        Console.WriteLine("Please enter Integer {0} now.", (attempt + 1));
        int output;
        while (!int.TryParse(Console.ReadLine(), out output))
            Console.WriteLine("This is not a valid integer. Please enter a valid integer now:");
        return output;
    }
