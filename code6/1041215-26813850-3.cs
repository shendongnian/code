    static void SomeOtherMethod()
    {
        DoSomethingWithPlayer(Player[1]) // Jeffy Jones from the example
    }
    static void DoSomethingWithPlayer(string player)
    {
        string[] p = player.Split((char)','); // create an instance array representing the player
        string firstName = p[0];
        string lastName = p[1];
        int playerNumber = int.TryParse(p[2]);
        int playerPoints = itn.TryParse(p[3]);
        // some code to work with this player or call methods on this player
        // the collection 'p' is an instance that goes away after this method completes
    }
