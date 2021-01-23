    static void ResetGame() {
        Console.WriteLine("Welcome to the game!");
        Console.Write("How many player will be taking part today: ");
        string playerNo = Console.ReadLine();
        int amountofPlayers = int.Parse(playerNo);
        players = new Player[amountOfPlayers];
        ...
    }
