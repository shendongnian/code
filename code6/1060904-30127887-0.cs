    [Authorize()]
    ActionResult Details()
    {
      var UserId = User.Identity.GetUserId();
      var comp = db.AspNetUsers.Where(i => i.UserName== UserId).First();
      
      return View(comp);
    }
