    private static double GetDoubleFromUser(string prompt)
    {
        double result;
        while (true)
        {
            if (prompt != null) Console.Write(prompt);
            var input = Console.ReadLine();
            if (double.TryParse(input, out result)) break;
            Console.WriteLine("Sorry, that is not a valid number. Please try again...");
        }
        return result;
    }
