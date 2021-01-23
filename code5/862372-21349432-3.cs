    // GET: /Team/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Team team= db.Team.Find(id); //assuming that this is the id of the team
        if (team== null)
        {
            return HttpNotFound();
        }
        var teamViewModel = new TeamViewModel() { Team = team, Player = new Player() }; 
        return View(teamViewModel);
    }
