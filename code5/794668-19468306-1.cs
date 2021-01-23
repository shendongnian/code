    [HttpPost]
    public ActionResult StopScheduled([Bind(Prefix = "item")]  BillPayModel model)
    {
             try
             {
                 if (ModelState.IsValid)
                 {
                    //save stuff into db
                     db.SaveChanges();
                 }
                 else
                 {
                     ModelState.AddModelError("", "Could not Stop Scheduled Payment");
                 }
             }
             catch (FormatException)
             {
                 ModelState.AddModelError("", "Could not Stop Scheduled Payment");
             }
             return View(model);
    }
