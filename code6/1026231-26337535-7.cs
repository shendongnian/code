    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(MembersViewModel members)
    {
       // From here you may want to again map the data from MembersViewModel to the table objects and do the rest of operation as you have done below
            db.Entry(member).State = EntityState.Modified;
            db.Entry(add).State = EntityState.Modified;
            db.Entry(con).State = EntityState.Modified;
            db.SaveChanges();
    }
