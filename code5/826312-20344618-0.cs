    static Player[] players;
    static int amountofPlayers;
    static void ResetGame()
    {
        Console.WriteLine("Welcome to the game!");
        Console.Write("How many player will be taking part today: ");
        string playerNo = Console.ReadLine();
        amountofPlayers = int.Parse(playerNo);
        
        if (amountofPlayers <= 4)
        {
            players = new Player[amountofPlayers];
            for (int i = 0; i < amountofPlayers; i = i + 1)
            {
                int displayNumber = i + 1;
                Console.Write("Please enter the name of player " + displayNumber + ": ");
                players[i].Name = Console.ReadLine(); //error is here
            }
        }
        else
        {
            Console.WriteLine("Please enter a number of players less than 4!");
        }
    }
