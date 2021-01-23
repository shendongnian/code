    public static int GetIntFromUser(string prompt,
        string errorMessage = "Invalid entry. Please try again.")
    {
        int value;
        while (true)
        {
            if (prompt != null) Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value)) break;
            if (errorMessage != null) Console.WriteLine(errorMessage);
        }
        return value;
    }
