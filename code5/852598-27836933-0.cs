    [HttpPost]
    public ActionResult Vote(long id, VoteDirection vote)
    {
    
      IISTaskManager.Run(() =>
      {
          ...
      }
      );
    
    return View("Success");
