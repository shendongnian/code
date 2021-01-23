    [HttpPost]
    public ActionResult AddToPreRank(int id){
        Player player= new Player();
        player = db.Players.Find(id);
        return Json(new {player});
    }
