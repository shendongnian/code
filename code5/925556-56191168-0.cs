    private ApplicationDbContext db;
    // api methods
    public JsonResult methodA(string id){
        Resource resource = db.Resources.Find(g);
        db.Entry(resource).State = EntityState.Modified;
        db.SaveChanges();
        return methodB()
    }
    
    public JsonResult methodB(string id){
        Resource resource = db.Resources.Find(id);
        db.Entry(resource).State = EntityState.Modified;
        db.SaveChanges();
        return new JsonResult();
    }
I changed method B to have a using statement and rely only on the local *db2*.
After:
    private ApplicationDbContext db;    
    // api methods    
    public JsonResult methodA(string id){
        Resource resource = db.Resources.Find(g);
        db.Entry(resource).State = EntityState.Modified;
        db.SaveChanges();
        return methodB()
    }
    public JsonResult methodB(string id){
        using (var db2 = new ApplicationDbContext())
        {
            Resource resource = db2.Resources.Find(id);
            db2.Entry(resource).State = EntityState.Modified;
            db2.SaveChanges();
        }
        return new JsonResult();
    }
