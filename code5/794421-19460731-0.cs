    private Task<PlayerDetails> GetPlayerDetailsAsync(double playerId)
    {
        return con.GetPlayer(playerId);
    }
    con.GetGame(id, game => {
        var tasks = game.Team1
                        .Select(p => new { Player=p, Details=GetPlayerDetailsAsync(p.Id)})
                        .ToList(); // Force all tasks to start...
        foreach(var t in tasks)
        {
            t.Player.SomeExtraDetails = await t.Details;
        }
        // all player data is now set on all players
    });
