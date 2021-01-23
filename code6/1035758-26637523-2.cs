    List<Player> players = GetPlayers();
    Player winner = null;
    int round = 0;
    while (winner == null)
    {
        round++;
        AnnounceRound(round);
        foreach(Player p in players)
        {
            p.ResetDarts();
            AnnouncePlayer(p);
            while (p.HasUnthrownDarts)
            {
                p.ThrowDart();
    
                if (p.Score >= 501)
                {
                    winner = p;
                    break;
                }
            }
            
            if (winner != null) break;
         }
    }
    
    Console.WriteLine("We have a winner! Congratulations, {0}!!", winner.Name);
    
    Console.WriteLine("The final scores are:");
    
    foreach(Player p in players.OrderByDescending(p => p.Score))
    {
        Console.WriteLine(" {0}: {1}", p.Name, p.Score);
    }
