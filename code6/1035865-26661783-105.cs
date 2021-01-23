    private static void Main()
    {
        Console.Write("Would you like to play a game of darts (y/n)? ");
        var playGame = Console.ReadKey();
        List<Player> players = null;
        while (playGame.Key == ConsoleKey.Y)
        {
            Console.WriteLine(Environment.NewLine);
            if (players == null)
            {
                players = GetPlayers();
            }
            else
            {
                players.ForEach(p => p.Reset());
            }
            . . .
            Console.Write("{0}Would you like to play another game (y/n)? ", 
                Environment.NewLine);
            playGame = Console.ReadKey();
        }
        Console.Write("{0}Thanks for playing! Press any key to quit...", 
            Environment.NewLine);
        Console.ReadKey();
    }
