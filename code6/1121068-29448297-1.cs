    while (true)
    {
        keyPressed = Console.ReadKey();
        switch (keyPressed.Key)
        {
            case ConsoleKey.Enter:
                Console.WriteLine("You pressed the Enter Key!");
                continue;
            case ConsoleKey.Escape:
                Console.WriteLine("You pressed the Escape Key!");
                continue;
            case ConsoleKey.Spacebar:
                Console.WriteLine("You pressed the Spacebar!");
                continue;
        }
        // should be outside the switch for breaking the loop
        break;
    }
