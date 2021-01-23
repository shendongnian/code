    public void WriteLine(string message)
    {
    #if DEBUG
        Console.WriteLine(message);
    #endif
    }
