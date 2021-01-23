    public ActionResult Save(int id)
    { 
        return View(repository.GetUserById(id));
    }
    
    
    [HttpPost]
    public ActionResult Save(UserEditModel model) {
        try {
            repository.SaveUser(model.CopyTo());
            return RedirectToAction("Index", "Users", new { page = model.Page });
        }
        catch (InvalidOperationException ex) {
            TempData["UserError"] = ex.Message; 
            return View(model);
        }
    }
