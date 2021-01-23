    public ActionResult Index_Read()
    {
        var teamCount = repository.Team.Count();
        var result = repository.Student.GroupBy(g => g.TeamName).Select(s => new StudentViewModel { TeamName = s.Key, TeamPercentage = s.Count()/teamCount });
        // Imagine result contains something like this: { TeamName = "Team 1", TeamPercentage = "20" }, { TeamName = "Team 2", TeamPercentage = "30" }, { TeamName = "Team 3", TeamPercentage = "10" }, { TeamName = "Team 4", TeamPercentage = "40" }
	    return View(result);
    }
