    [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                entity.Entry(project).State = EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(project);
        }
