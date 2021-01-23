    private static double GetDoubleFromUser(string prompt)
    {
        double input;
        while (true)
        {
            if (prompt != null) Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out input)) break;
            Console.WriteLine("Sorry, that is not a valid number. Please try again.");
        }
        return input;
    }
