    /// <summary>
    /// Written by fredrik92 (http://social.msdn.microsoft.com/Forums/vstudio/en-US/08163199-0a5d-4057-8aa9-3a0a013800c7/how-to-write-a-command-like-pause-to-console?forum=csharpgeneral)
    /// Writes a message to the console prompting the user to press a certain key in order to exit the current program.
    /// This procedure intercepts all keys that are pressed, so that nothing is displayed in the Console. By default the
    /// Enter key is used as the key that has to be pressed.
    /// </summary>
    /// <param name="key">The key that the Console will wait for. If this parameter is omitted the Enter key is used.</param>    
    public static void WriteKeyPressForExit(ConsoleKey key = ConsoleKey.Enter)
    {
        Console.WriteLine();
        Console.WriteLine("Press the {0} key on your keyboard to exit . . .", key);
        while (Console.ReadKey(intercept: true).Key != key) { }
    }
