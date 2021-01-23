    public ActionResult UpdateTable(Table t)
    {
        var up = _dbContext.Table.Find(t.ID);  //t.ID is  Primary Key
        up.Name = t.Name;
        // All the fields you need to update
        _dbContext.Entry(Table).State = EntityState.Modified;
        _dbContext.SaveChanges();
         return View(up);
            
    }
