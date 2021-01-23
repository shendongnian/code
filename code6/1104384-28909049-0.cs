    int tmpLives;
    if (Int32.TryParse(Console.ReadLine(), out tmpLives))
    {
        lives = tmpLives;
    }
    else
    {
        AskLives();
    }
