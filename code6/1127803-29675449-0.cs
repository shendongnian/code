    private ApplicationDbContext db = null;
    public ApplicationDbContext Db {
        get {
            if (db == null)
                db = new ApplicationDbContext();
            return db;
        }
    }
