    [HttpPost]
    public ActionResult Create(dataOffender offender)
    {
       if (ModelState.IsValid)
       {
         db.dataOffenders.Add(offender);
         db.SaveChanges();
         return RedirectToAction("CreateCharge", new KeyValuePair(offender.Key, offender.Value));
       }
       return View(offender);
    }
    public ActionResult CreateCharge(KeyValuePair kvp)
    {
       ViewBag.OffenderKeyValue = kvp;
       return View();
    }
