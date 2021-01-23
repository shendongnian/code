    // Model class for View
    public class UsersPerTeamCount
    {
        public string TeamName { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
    
    // ...
    
    public ActionResult PlayersPerTeam()
    {
        var model = Teams.Join(Users.DefaultIfEmpty().
            t => t.TeamId,
            u => u.TeamId,
            (t, u) => new { t.TeamName, t.Description, UserId = u == null ? null:(int?)u.UserId })
        .GroupBy(x => x)
        // below we're creating our UsersPerTeamCount objects rather than anon objects for strongly typed use in the view
        .Select(g => new UsersPerTeamCount() { g.Key.TeamName, g.Key.Description, Count = g.Count() });
    
        return View(model);
    }
