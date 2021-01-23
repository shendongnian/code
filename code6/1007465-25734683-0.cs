    _db.Entry(candidat).State = EntityState.Modified;
    // Ignore changes to the value of SomeProperty
    _db.Entry(candidat).Property("SomeProperty").IsModified = false;
    _db.SaveChanges();
    
