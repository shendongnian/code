    while (true)
    {
        keyPressed = Console.ReadKey();
        if (keyPressed.Key == ConsoleKey.Enter)
        {
            Console.WriteLine("You pressed the Enter Key!");
            continue;
        }
        if (keyPressed.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("You pressed the Escape Key!");
            continue;
        }
        if (keyPressed.Key == ConsoleKey.Spacebar)
        {
            Console.WriteLine("You pressed the Spacebar!");
            continue;
        }
        break;
    }
