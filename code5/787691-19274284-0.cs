    Console.WriteLine("Press BACKSPACE to return to main menu, or ESC to quit.");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Backspace)
    {
        menuOption = Console.ReadLine();
    
    }else if (key.Key == ConsoleKey.Escape){
    
        Environment.Exit(0);
    }
