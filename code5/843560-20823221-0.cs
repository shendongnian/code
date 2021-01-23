     [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(string id)
    {
        if (ModelState.IsValid)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ProjectId = new SelectList(db.ProjectDetails, "ProjectDetailId", "TargetAudience", project.ProjectId);
        ViewBag.ProjectTypeId = new SelectList(db.ProjectTypes, "ProjectTypeId", "ProjectTypeName", project.ProjectTypeId);
        ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", project.UserId);
        return View(project);
    }
