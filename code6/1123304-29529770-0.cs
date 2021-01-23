    [HttpPost]
    public ActionResult Edit(Events_Info_tbl events_info_tbl)
    {
        if (ModelState.IsValid)
        {
            //Save
    
            return RedirectToAction("Index");
        }
    
        //Return view
        //NOTE: Make sure your page state is preserved i.e. your modal is open
        return View(events_info_tbl);
    }
    
    [ChildActionOnly]
    public PartialViewResult RenderEditForm(int id)
    {
        //Build form data
        return PartialView("_EditForm");
    }
