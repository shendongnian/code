    public KashDbContext : DbContext
    {
        public int SaveChanges()
        {
            Database.ExecuteSqlCommand(Constants.SqlQuery);
            base.SaveChanges();
        }
    
        //Do for all methods
    }
