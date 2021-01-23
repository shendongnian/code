    public void UpdateMed(meds med)
    {
        if (ModelState.IsValid)
        {
            db.meds.Attach(med);
            db.Entry(med).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
