    public static void WriteWithTimestamp(dynamic value)
    {
        Console.Write(DateTime.Now.ToString());
        Console.Write(": ");
        Console.Write(value);
    }
