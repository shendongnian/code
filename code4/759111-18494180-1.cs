    [HttpPost]
    public ActionResult Create(MyViewModel model)
    {
        if (ModelState.IsValid)
        {
            var db = new DefaultConnection(); (?? is this what your context is called?)
            db.users.Add(new User{
               Id_Company = model.u.Id_Company, 
               Name = model.u.Name
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(model);
    }
