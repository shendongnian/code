    public ActionResult CreateUser()
    {
        var model = new CreateNewUser();
        return View(model);
    }
    
    [HttpPost]
    public ActionResult CreateUser(CreateNewUser model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
    
        //Model is valid so continue...
        return null;
    }
