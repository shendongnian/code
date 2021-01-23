    try
    {
        using (Game1 game = new Game1())
        {
            game.Run();
        }
    }
    catch(Exception E)
    {
        Console.WriteLine(e.StackTrace);
    }
