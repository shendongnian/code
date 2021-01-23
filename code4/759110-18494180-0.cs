    [HttpPost]
    public ActionResult Create(MyViewModel model)
    {
        if (ModelState.IsValid)
        {
            db.users.Add(new User{
               Id_Company = model.u.Id_Company, 
               Name = model.u.Name
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(model);
    }
