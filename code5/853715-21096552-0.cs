		[HttpGet]
		public ActionResult Index()
		{
                        var team = new FooModel();
                        var teamMembers = new List<TeamMember>();
                        teamMembers.Add(new TeamMember { Name = "Bob" });
                        team.TeamMembers = teamMembers;
                        return View(team);
		}
