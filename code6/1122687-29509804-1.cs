    [Authorize]
    public ActionResult AdminIndex() //From the link mentioned above
    {
        return View(ss.SystemUsers.ToList());
    }
 
