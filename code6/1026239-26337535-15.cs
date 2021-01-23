    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(MembersViewModel members)
    {
       // From here you may want to again map the data from MembersViewModel to the table objects and do the rest of operation as you have done below
       // 1. Get the data table objects
       // 2. Assign the data from the MembersViewModel to the respective data tables which is similarly done in [HttpGet] method.
       // 3. Then save the changes as below.
            db.Entry(member).State = EntityState.Modified;
            db.Entry(add).State = EntityState.Modified;
            db.Entry(con).State = EntityState.Modified;
            db.SaveChanges();
    }
