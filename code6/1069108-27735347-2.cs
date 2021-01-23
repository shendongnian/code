    public static decimal GetDecimalFromUser(string prompt,
        string errorMessage = "Invalid entry. Please try again.")
    {
        decimal value;
        while (true)
        {
            if (prompt != null) Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out value)) break;
            if (errorMessage != null) Console.WriteLine(errorMessage);
        }
        return value;
    }
