    [HttpPost]
    public ActionResult Create(dataOffender offender)
    {
       if (ModelState.IsValid)
       {
         db.dataOffenders.Add(offender);
         db.SaveChanges();
         return RedirectToAction("CreateCharge");
       }
       return View(offender);
    }
