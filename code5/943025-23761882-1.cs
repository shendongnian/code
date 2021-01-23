    [HttpPost]
    public ActionResult Edit(User model)
    {
        if (ModelState.IsValid)
        {
            User u = new User();
            u.Update(model);
        }
        return RedirectToAction("Index", "Users");
    }
    public void Update(User u)
    {
        var user = GetUserById(u.UserId);
        TryUpdateModel(user); // You forgot this 
        db.Entry(user).State = EntityState.Modified;
        db.SaveChanges();
    }
