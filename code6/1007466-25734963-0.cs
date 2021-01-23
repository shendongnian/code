    [HttpPost]
    public ActionResult Edit(Candidat candidat)
    {
        ProcRecDB _db = new ProcRecDB();  //  from DbContext
    
        if (ModelState.IsValid)
        {
            var updatedCandidat = new Candidat { Id = candidat.Id };
    
            _db.Attach(updatedCandidat);
    
            // Set the properties that you would like to update. This must be
            // done after the object has been attached to the db context.
            updatedCandidat.FirstName = candidat.FirstName;
            updatedCandidat.LastName = candidat.LastName;
            ...
            
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(candidat);
    }
