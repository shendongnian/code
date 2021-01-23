    public ActionResult EditNext(int id)
    {
        Page next= db.Pages.Where(x => x.Id > id).ToList().FirstOrDefault();
        return View("~/Areas/Admin/Views/Pages/Edit.cshtml", next);
    }
    
    public ActionResult EditPrev(int id)
    {
        Page prev = db.Pages.Where(x => x.Id < id).ToList().OrderByDescending(y => y.Id).FirstOrDefault();
        return View("~/Areas/Admin/Views/Pages/Edit.cshtml", prev);
    }
