    [HttpPost]
    public ActionResult Edit(Movie movie)
    {
        try
        {
            //Get DB version
            var originalMovie = (from m in _db.Movies where m.Id == movie.Id select m).First();
            //Mark changes with data received
            _db.Movies.ApplyCurrentValues(movie);
            //CODE ADDED - Ignoring field/properties you dont want to update to DB
            ObjectStateEntry entryToUpdate = db.ObjectStateManager.GetObjectStateEntry(originalMovil);
            entryToUpdate.RejectPropertyChanges("field1");
            entryToUpdate.RejectPropertyChanges("field2");
            entryToUpdate.RejectPropertyChanges("field3");
            //-----------------
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
