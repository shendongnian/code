    TeamDBContext db = new TeamDBContext();
    //create a new player
    Player p = new Player() {Name="make", Age=10, Salary=10, Gender="m" };
    db.Players.Add(p);
    db.SaveChanges();
    //create a new team
    Team t = new Team () {TeamName="barcelona", SportType="soccer"};
    db.Teams.Add(t);
    db.SaveChanges();
    
    //add a player to a team
    db.Teams.Include("Players").Players.Add(p);
    db.SaveChanges();
