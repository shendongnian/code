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
        var model = from t in db.Teams
                        join u in db.Users on t.TeamId equals u.TeamId into joinedRecords
                        select new UsersPerTeamCount()
                        {
                            Name = t.TeamName,
                            Description = t.Description,
                            PlayerCount = joinedRecords.Count()
                        };
    
        return View(model);
    }
