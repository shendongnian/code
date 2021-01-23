    // ReadKey is called for the first time...
    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
    {
        Console.Clear();
        return 2; // Quit Game
    }
    else // ...if it wasn't Enter...
    {
        // ...ReadKey is called a second time.
        if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
        {
            Console.Clear();
            return Menu(); // Recursion :)
        }
    }
