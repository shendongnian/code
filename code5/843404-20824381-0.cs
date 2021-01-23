    [HttpPost]
    public ActionResult Edit(Item item)
    {
        if (ModelState.IsValid)
        {
            User user = db.Users.Find(2); // find the user; later implement the session
            db.Items.Attach(item);  // attach item manually to track changes of Relational object of item
            db.Entry(item).Reference(i => i.ModifiedBy).Load();  // load the User object of item property ModifiedBy; since it is virtual aka lazy loading
            item.ModifiedBy = user; // assing user to ModifiedBy
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(item);
    }
