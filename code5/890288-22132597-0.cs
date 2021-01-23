    Console.Clear();
    Console.WriteLine("Option 1");
    Console.WriteLine("Option 2");
    Console.WriteLine("Option 3");
    Console.WriteLine();
    Console.Write("input: ");
    var originalpos = Console.CursorTop;
    var k = Console.ReadKey();
    var i = 2;
    while (k.KeyChar != 'q')
    {
               
        if (k.Key == ConsoleKey.UpArrow)
        {
                    
             Console.SetCursorPosition(0, Console.CursorTop - i);
             Console.ForegroundColor = ConsoleColor.Black;
             Console.BackgroundColor = ConsoleColor.White;
             Console.WriteLine("Option " + (Console.CursorTop + 1));
             Console.ResetColor();
             i++;
                    
        }
        Console.SetCursorPosition(8, originalpos);
        k = Console.ReadKey();
     }
