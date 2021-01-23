    public static void WriteLineAtPosition(string format, params object[] parameters)
    {
        Console.SetCursorPosition(20);
        Console.WriteLine(format, parameters);
    }
