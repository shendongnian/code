    [HttpPost]
    public ActionResult Create(Employee emp)
    {
         try
         {
             if (ModelState.IsValid)
             {
                 db.Employees.Add(emp);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(emp);     
         }
         catch (DbEntityValidationException e)
         {
             foreach (var eve in e.EntityValidationErrors)
             {
                  System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                  eve.Entry.Entity.GetType().Name, eve.Entry.State);
                  foreach (var ve in eve.ValidationErrors)
                  {
                       System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    ve.PropertyName, ve.ErrorMessage);
                  }
             }
             throw;
         }
    }
