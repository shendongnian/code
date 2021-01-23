    [HttpPost]
    public ActionResult Create(dataOffender offender)
    {
       if (ModelState.IsValid)
       {
         db.dataOffenders.Add(offender);
         db.SaveChanges();
         return RedirectToAction("CreateCharge", new { offenderId = offender.Id });
       }
       return View(offender);
    }
    public ActionResult CreateCharge(int offenderId)
    {
       ViewBag.OffenderId = offenderId;
       return View();
    }
