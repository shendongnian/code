    [HttpPost]
            public ActionResult Create(MyViewModel model)
            {
                if (ModelState.IsValid)
                {
                    db.users.Add(model.User);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                return View(model);
            }
