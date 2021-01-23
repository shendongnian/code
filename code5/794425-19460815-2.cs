    con.GetGame(id, game => {
        var tasks = new List<Task>();
        foreach(Player p in game.Team1)
        {
            tasks.Add(Task.Run(async () => p.SomeExtraDetails = await GetPlayerDetailsAsync(p.Id)));
        }
        Task.WaitAll(tasks.ToArray());
    });
    private Task<PlayerDetails> GetPlayerDetailsAsync(double playerId)
    {
        return con.GetPlayerAsync(playerId);
    });
