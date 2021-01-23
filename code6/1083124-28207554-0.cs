    private static bool hasExitedApp; // flag to be used for exiting
    private static void Main(string[] args)
    {
        Console.WriteLine("Application is running...");
        performAsynchronousWait();
        Console.WriteLine("Application is still running...");
        // do other processes here
    }
    private async static void performAsynchronousWait()
    {
        while (!hasExitedApp)
            await Task.Delay(100); // Task.Delay uses a timer, so there's no blocking the UI
        Console.WriteLine("Has excited the application...");
        // do shutdown processes here
    }
