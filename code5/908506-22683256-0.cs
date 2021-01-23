    Public ActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {   
          UserContext userContext = new UserContext();
          userContext.users.Add(user);
          userContext.SaveChanges();
          return RedirectToAction("ShowUsers");
         }
      return View(user);
    }
