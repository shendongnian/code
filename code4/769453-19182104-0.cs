    [HttpPost]
    public ActionResult Edit(int id, BlogView view)
    {
        try
        {
            Blog blog = Mapper.Map(view);      //map view model to domain object using eg. Automapper
            db.Entry(blog).State = EntityState.Modified;
            db.SaveChanges();
           return RedirectToAction("Index");
        }
        catch(DbEntityValidationException ex)
        {
            var error = ex.EntityValidationErrors.First().ValidationErrors.First();
            this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            return View();
        }
    }
