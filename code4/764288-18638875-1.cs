    [HttpPost]
    public ActionResult EditUser(user model)
    {
       if (ModelState.IsValid)
       {
           model.ModelState = ModelState;
           _userService.Update(model);
       }
       if (ModelState.IsValid)
       {
           // Edit user was successful - No validation issues in business logic.
           return View("Users"); 
       }
       return View(model);
    }
