    public ActionResult Index_Read()
    {
        var teamCount = repository.Team.Count();
        var result = repository.Student.GroupBy(g => g.TeamName).Select(s => new StudentViewModel { category = s.Key, value = s.Count()/teamCount });
        // Imagine result contains something like this: { category = "Team 1", value = "20" }, { category = "Team 2", value = "30" }, { category = "Team 3", value = "10" }, { category = "Team 4", value = "40" }
	    return View(result);
    }
