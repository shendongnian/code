    int position = 1;
    for (int i = 0; i <= onechunk * progress; i++)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.CursorLeft = position++;
        Console.Write(" ");
    }
