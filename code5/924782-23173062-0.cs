    public static void WriteLineInGreen(static Console, string formatString,
                                        params object[] args)
    {
        Console.ForeGround = ConsoleColor.Green;
        Console.WriteLine(formatString, args);
    }
