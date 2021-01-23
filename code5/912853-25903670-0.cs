        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser u = UserManager.FindById(model.Id);
                u.UserName = model.Email;
                u.Email = model.Email;
                u.StaffName = model.StaffName; // Extra Property
                UserManager.Update(u);
                return RedirectToAction("Index");
            }
            return View(model);
        }
