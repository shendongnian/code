    public ActionResult TeamStat()
    {
      var players = db.Players().ToList();
      var seasons = db.Seasons().ToList();
      var view = new TeamStat()
      {
        Players = players,
        Seasons = seasons
      };
      return View(view);
    }
