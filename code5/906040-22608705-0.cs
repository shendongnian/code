    DateTime endTime = DateTime.Now.AddSeconds(2);
    while (!Console.KeyAvailable && DateTime.Now < endTime)
        Thread.Sleep(1);
    if (Console.KeyAvailable)
    {
        var keyPress = Console.ReadKey();
        string keyPressString = keyPress.KeyChar.ToString();
        keyPressString = keyPressString.ToUpper();
        if (keyPressString == lettersAndChars)
        {
            Console.Clear();
            goto Start;
        }
    }
    Console.Clear();
    Console.WriteLine("Game Over");
