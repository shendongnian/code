    public ActionResult Edit(BranchViewModel model)
    {
        if (ModelState.IsValid)
        {
            Branch branch = db.Branch.Find(model.BranchId);
            if (branch.BranchName != model.BranchName)
            {
                branch.BranchName = model.BranchName;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        return View(model);
    }
