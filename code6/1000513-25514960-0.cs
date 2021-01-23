    public IList<Games> GetTopGamesForMachine(PinballMachine machine, int maxItems)
    {
         return Session
             .Query<Games>()
             .Where(g => g.PinballMachine == machine)
             .OrderByDescending(g => g.Score)
             .Take(maxItems)
             .ToList();
    }
