    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterMale(UserStats model)
        {
    
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(i => i.ID == model.userID );
                db.UserStats.Add(userstats);
                db.SaveChanges();
                return RedirectToAction("Details", "Dashboard", new { id = userstats.ID });
            }
    
            return View(userstats);
        }
