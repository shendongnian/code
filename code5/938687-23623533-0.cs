    var team = new Team();
    team.FirstName = "FirstName";
    team.LastName = "LastName";
    
    var baseballTeam = new BaseBallTeam();
    baseballTeam.TotalSaves = 100;
    
    team.PreferredSportsTeam = new ExpandoObject();
    team.PreferredSportsTeam.BaseBallTeam = baseballTeam;
