    public static void Upper(char[] array, string input)
    {
        Console.WriteLine("Reverse array :");
        Console.Write(new string(input.AsEnumerable().Reverse().ToArray()));
    }
