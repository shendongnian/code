    var key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Enter)
    {
        Console.Clear();
        return 2; // Quit Game
    }
    else
    {
        if (key == ConsoleKey.UpArrow)
        {
            Console.Clear();
            return Menu(); // Recursion :)
        }
    }
