    public void InsertOrUpdateFoo(DbContext db, Foo foo) {        
        if (foo.ID == 0) { // assuming Foo's unique identifier is named ID
            db.Entry(entity).State = EntityState.Added;
        } else {
            db.Entry(entity).State = EntityState.Modified;
        }
        db.SaveChanges();
    }
