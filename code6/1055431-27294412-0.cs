    if (ModelState.IsValid)
    {
        var member = db.Members.Find(vm.m_id);
        member.title_id = vm.title_id;
        ViewBag.Titles = new SelectList(db.Titles.ToList(), "title_id", "Titles", vm.title_id);   
        db.SaveChanges();
        return RedirectToAction("Index");
    
    }
